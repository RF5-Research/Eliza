using System.Collections.Generic;
using static Eliza.Core.Serialization.Attributes;

namespace Eliza.Model.SaveData
{
	public class RF5StatusData
	{
		[MessagePackRaw]
		public int Unk;
		public Dictionary<int, HumanStatusData> HumanStatusDatas;
		public List<FriendMonsterStatusData> FriendMonsterStatusDatas;
	}
}
