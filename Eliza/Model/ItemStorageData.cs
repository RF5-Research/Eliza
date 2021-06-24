using MessagePack;

namespace Eliza.Model
{
    [MessagePackObject]
	public class ItemStorageData
	{
		[Key(0)]
		public ItemData[] ItemDatas;
	}
}
