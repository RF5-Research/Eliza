using MessagePack;
using UnityEngine;

namespace Eliza.Model
{
	[MessagePackObject]
	public class FieldOnGroundItemInfo
	{
		// Fields
		[Key(0)]
		public int FieldSceneId;
		[Key(1)]
		public ItemData ItemData;
		[Key(2)]
		public Vector3 Position;
		[Key(3)]
		public float AxisY;
		//[IgnoreMemberAttribute]
		//public OnGroundItem OnGroundItem;
	}
}