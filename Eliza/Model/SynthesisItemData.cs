using MessagePack;

namespace Eliza.Model
{
    [MessagePackObject]
    public class SynthesisItemData : NotAmountItemData
    {
        [Key(2)]
        public int[] SourceItems;
    }
}
