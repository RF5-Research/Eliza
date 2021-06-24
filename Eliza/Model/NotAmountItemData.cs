using MessagePack;

namespace Eliza.Model
{
    [MessagePackObject]
    public abstract class NotAmountItemData : ItemData
    {
        [Key(1)]
        public int Level;
        [IgnoreMember]
        private bool Poped;
    }
}
