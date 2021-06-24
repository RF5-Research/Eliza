using MessagePack;

namespace Eliza.Model
{
    [MessagePackObject]
    public class PotToolItemData : EquipItemData
    {
        [Key(12)]
        public int Capacity;
    }
}
