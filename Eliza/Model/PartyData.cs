using MessagePack;

namespace Eliza.Model
{
    [MessagePackObject]
	public class PartyData
	{
		[Key(0)]
		public int PartyNo;
		[Key(1)]
		public int PartyType;
		[Key(2)]
		public int ActorId;
		[Key(3)]
		public uint DataID;
		[Key(4)]
		public EnemyStatusData StatusData;
		[Key(5)]
		public int PartyOutTime;
	}
}
