using MessagePack;

namespace Eliza.Model
{
    [MessagePackObject]
    public class PotToolItemData : EquipItemData
    {
        [Key(12)]
        public int Capacity;

        public PotToolItemData()
        {
            AddedItems = new int[0];
            ArrangeItems = new int[0];
            SourceItems = new int[0];
        }
    }
}
