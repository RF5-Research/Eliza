using MessagePack;

namespace Eliza.Model
{
	[MessagePackObject(keyAsPropertyName: true)]
    public class EventUnlockFlagData
    {
		public int ScriptId;
		public int EventPointId;
		public int EventCheckType;
		public long EventStartDay;
		public int EventStartTime;
		public int EventEndTime;
		public int IconType;
		public int IconViewType;
		public int PointOnFlag;
		public int StoryFlag;
		public int DeleteEventPointFlag;
		public int[] On;
		public int[] Off;
		public int[] NpcOn;
		public int[] NpcOff;
		public int[] FlagOn;
		public int[] FlagOff;
		public bool PointActive;
		public int SceneId;
		public float PosX;
		public float PosY;
		public float PosZ;
	}
}
