using MessagePack;

namespace Eliza.Model
{
    [MessagePackObject]
	public class FieldOnGroundItemStorage
	{
		[Key(0)]
		public FieldOnGroundItemInfo[] Datas;
	}
}
