using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;
using System.Text;

namespace Eliza.Core
{
    public class Cryptography
    {
        public static byte[] Encrypt(byte[] data)
        {
            return RijndaelCrypto(data, true);
        }

        public static byte[] Decrypt(byte[] data)
        {
            return RijndaelCrypto(data, false);
        }

        public static byte[] RijndaelCrypto(byte[] data, bool isEncrypting)
        {
            //RF5 uses 256bit block Rijndael Encryption
            var aesKey = Encoding.UTF8.GetBytes("1cOSvkZ4HQCi6z/yQpEEl4neB+AIXwTX");
            var aesIV = Encoding.UTF8.GetBytes("XuMigxpK61gLwgo1RsreLLGPcw3vJFze");
            var engine = new RijndaelEngine(256);
            var blockCipher = new CbcBlockCipher(engine);
            var cipher = new BufferedBlockCipher(blockCipher);
            var keyParam = new KeyParameter(aesKey);
            var keyParamWithIV = new ParametersWithIV(keyParam, aesIV, 0, 32);

            cipher.Init(isEncrypting, keyParamWithIV);
            var output = new byte[cipher.GetOutputSize(data.Length)];
            var length = cipher.ProcessBytes(data, output, 0);
            cipher.DoFinal(output, length);
            return output;
        }

        public static uint Checksum(byte[] buffer)
        {
            uint sum = 0xcbf29ce4;
            uint lo = 0;
            uint running_sum = 0x39;
            for (int index = 0; index < buffer.Length; index++)
            {
                uint value = buffer[index];
                uint delta = value - lo;
                lo = (lo & 0xff) + 0xb2;
                sum = sum * 0x1b3 ^ (delta ^ running_sum) & 0xff;
                running_sum = value;
            }
            return sum;
        }
    }
}
