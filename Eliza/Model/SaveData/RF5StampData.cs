using static Eliza.Core.Serialization.Attributes;

namespace Eliza.Model.SaveData
{
    public class RF5StampData
    {
        [Length(Max = 80)]
        public StampRecordData[] StampRecordData;
    }
}
