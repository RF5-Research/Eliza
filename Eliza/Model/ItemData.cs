using MessagePack;

namespace Eliza.Model
{
	[Union(0, typeof(AmountItemData))]
	[Union(1, typeof(SeedItemData))]
    [Union(2, typeof(FoodItemData))]
    [Union(3, typeof(EquipItemData))]
    [Union(4, typeof(RuneAbilityItemData))]
    [Union(5, typeof(FishItemData))]
    [Union(6, typeof(PotToolItemData))]
    [MessagePackObject]
	//[MessagePackFormatter(typeof(ItemDataFormatter))]
	public abstract class ItemData
	{
		[Key(0)]
		public int ItemID;
	}
}
