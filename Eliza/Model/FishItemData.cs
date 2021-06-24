using MessagePack;

namespace Eliza.Model
{
    [MessagePackObject]
    public class FishItemData : NotAmountItemData
    {
        [Key(2)]
        public int Size;
    }
}
