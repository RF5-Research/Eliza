using Eliza.Core.Serialization.MessagePackFormatters;
using MessagePack;

namespace Eliza.Model
{
    [MessagePackObject]
    [MessagePackFormatter(typeof(HumanStatusDataFormatter))]
    public class HumanStatusData : StatusDataBase
	{
        [Key(16)]
        public int ActorID;
        [Key(17)]
        public HumanEquip HumanEquip;
        [Key(18)]
        public int PartnerMovementOrderType;
        [Key(19)]
        public float DualSkillGauge;
    }
}