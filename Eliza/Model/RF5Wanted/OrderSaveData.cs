using MessagePack;
using System.Collections.Generic;

namespace Eliza.Model.RF5Wanted
{
	[MessagePackObject]
    public class OrderSaveData
    {
        [Key(0)]
        public int OrderClearCount;
        [Key(1)]
        public List<OrderSaveParameter> AcceptOrderParameters;
        [Key(2)]
        public List<OrderLotterySaveParameter> LotteryBoardOrderDatas;
        [Key(3)]
        public List<OrderLotterySaveParameter> LotteryNpcOrderDatas;
        [Key(4)]
        public List<OrderSaveParameter> LotMasterOrderParameters;
    }
}
