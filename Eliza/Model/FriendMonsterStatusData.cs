using Eliza.Core.Serialization.MessagePackFormatters;
using MessagePack;

namespace Eliza.Model
{
    [MessagePackObject]
    [MessagePackFormatter(typeof(FriendMonsterStatusDataFormatter))]
    public class FriendMonsterStatusData : StatusDataBase
	{
        [Key(16)]
        public uint DataID;
        [Key(17)]
        public string Name;
        [Key(18)]
        public int MonsterDataID;
        [Key(19)]
        public int LovePoint;
        [Key(20)]
        public int TimeStamp;
        [Key(21)]
        public int FarmId;
        [Key(22)]
        public int HouseId;
        [Key(23)]
        public int RoomId;
        [Key(24)]
        public int PartyNo;
        [Key(25)]
        public int PartnerMovementOrderType;
        [Key(26)]
        public int FarmMonsterOrder;
        [Key(27)]
        public int FarmFieldWorkArea;
        [Key(28)]
        public bool IsBrushed;
        [Key(29)]
        public bool IsPresent;
        [Key(30)]
        public bool EsaGet;
        [Key(31)]
        public bool IsWorkedToday;
        [Key(32)]
        public bool IsSeededToday;
        [Key(33)]
        public bool IsYieldToday;
        [Key(34)]
        public int Bonus_HP;
        [Key(35)]
        public int Bonus_STR;
        [Key(36)]
        public int Bonus_INT;
        [Key(37)]
        public int Bonus_VIT;
    }
}
