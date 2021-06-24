using MessagePack;

namespace Eliza.Model
{
	[MessagePackObject]
	public class HumanEquip
	{
		[Key(0)]
		public ItemData[] EquipItems;
		//[IgnoreMember]
		//private EquipSlotType _CurrentWeaponSlot;
	}
}
