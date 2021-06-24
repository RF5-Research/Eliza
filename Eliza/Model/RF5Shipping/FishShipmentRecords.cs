using MessagePack;

namespace Eliza.Model.RF5Shipping
{
    [MessagePackObject]
    public class ShipmentItemRecords
    {
        [Key(0)]
        public int ItemId;
        [Key(1)]
        public int ItemDataTableIndex;
        [Key(2)]
        public int Pieces;
        [Key(3)]
        public long totalPrice;
        [Key(4)]
        public int maxLv;
        [Key(5)]
        public int crown;
    }
}
