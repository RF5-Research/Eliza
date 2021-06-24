using MessagePack;

namespace Eliza.Model
{
    [MessagePackObject]
    public class OrderLotterySaveParameter
	{
        [Key(0)]
        public int OrderId;
        [Key(1)]
        public int OrderRequestId;
        [Key(2)]
        public int TypeKey;
    }
}