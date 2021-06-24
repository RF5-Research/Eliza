namespace Eliza.Model
{
    public class SaveFlagStorage
    {
        public int Length;
        public byte[] Data;

        //public int Length { get; set; }
        //public byte[] Data { get; set; }

        public SaveFlagStorage(byte[] data, int length)
        {
            Data = data;
            Length = length;
        }
    }
}
