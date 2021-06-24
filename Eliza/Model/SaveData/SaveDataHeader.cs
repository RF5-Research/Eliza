using static Eliza.Core.Serialization.Attributes;

namespace Eliza.Model.SaveData
{
    public class SaveDataHeader
    {
        public ulong uid;
        public uint version;
        [Length(Size = 4)]
        public char[] project;
        public uint wCnt;
        public uint wOpt;
        public SaveTime saveTime;
    }
}
