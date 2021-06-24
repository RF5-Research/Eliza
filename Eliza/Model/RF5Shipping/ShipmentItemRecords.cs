using MessagePack;

namespace Eliza.Model.RF5Shipping
{
    [MessagePackObject]
	public class FishShipmentRecords
    {
        [Key(0)]
        public int ItemId;
        [Key(1)]
        public int ItemDataTableIndex;
        [Key(2)]
        public int sizeMax;
        [Key(3)]
        public int crown;
    }
}
