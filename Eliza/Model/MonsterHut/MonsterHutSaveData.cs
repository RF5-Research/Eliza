using MessagePack;

namespace Eliza.Model.MonsterHut
{
	[MessagePackObject]
    public class MonsterHutSaveData
    {
		[Key(0)]
		public int FarmId;
		[Key(1)]
		public bool MonsterHutReleaseState;
		[Key(2)]
		public int MonsterHutPlaceId;
		[Key(3)]
		public int AreaReleaseState;
		[Key(4)]
		public FriendMonsterIDAndHouseID[] MonsterIds;
		[Key(5)]
		public int[] YieldItems;
		[Key(6)]
		public int[] YieldLevels;
	}
}
