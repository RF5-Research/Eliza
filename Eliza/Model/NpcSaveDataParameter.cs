using MessagePack;

namespace Eliza.Model
{
    [MessagePackObject(keyAsPropertyName: true)]
	public class NpcDateSaveParameter
	{
		public int ProgressType;
		public int dateType;
		public int dateSpotID;
		public int NpcId;
		public int dateStartTime;
		public int meetingLimitTime;
		public int meetingEventPointOnFlag;
		public bool doSuppo;
		private static string[] SpotNameIdTable;
		private static bool isSpotNameInitialized;
	}
}
