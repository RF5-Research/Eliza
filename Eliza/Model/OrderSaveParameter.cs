using MessagePack;

namespace Eliza.Model
{
    [MessagePackObject]
	public struct OrderSaveParameter
	{
        [Key(0)]
        public int OrderId;
        [Key(1)]
        public int AcceptId;
        [Key(2)]
        public int OrderTargetCurrentAmount;
        [Key(3)]
        public int CompleteDate;
        [Key(4)]
        public bool RecievedOrder;
        [Key(5)]
        public bool Completed;
        [Key(6)]
        public bool GotReward;
        [Key(7)]
        public bool FirstCompleted;
        [Key(8)]
        public string CompletedEventStep;
    }
}
