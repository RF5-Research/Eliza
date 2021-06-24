using MessagePack;

namespace Eliza.Model
{
    [MessagePackObject]
    public abstract class StatusDataBase
	{
        [Key(0)]
        public int Level;
        [Key(1)]
        public int Exp;
        [Key(2)]
        public int Hp;
        [Key(3)]
        public int Rp;
        [Key(4)]
        public Parameter SaveParameter;
        [Key(5)]
        public int BadStatus;
        [Key(6)]
        public ItemData TemporaryStatus_UseItem;
        [Key(7)]
        public int TemporaryStatus_UseItem_Time;
        [Key(8)]
        public int TemporaryStatus_HotSpring;
        [Key(9)]
        public int TemporaryStatus_HotSpring_Time;
        [Key(10)]
        public int TemporaryStatus_Vaccination;
        [Key(11)]
        public int TemporaryStatus_Vaccination_Time;
        [Key(12)]
        public int Score_ATKUp_Level;
        [Key(13)]
        public int Score_ATKUp_Time;
        [Key(14)]
        public int Score_DEFUp_Level;
        [Key(15)]
        public int Score_DEFUp_Time;
    }
}
