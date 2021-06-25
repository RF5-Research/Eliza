using MessagePack;

namespace Eliza.Model
{
	[MessagePackObject]
    public class EventUnlockFlagData
    {
		[Key("ScriptId")]
		public int ScriptId;
		[Key("EventPointId")]
		public int EventPointId;
		[Key("eventCheckType")]
		public int eventCheckType;
		[Key("EventStartDay")]
		public long EventStartDay;
		[Key("EventStartTime")]
		public int EventStartTime;
		[Key("EventEndTime")]
		public int EventEndTime;
		[Key("IconType")]
		public int IconType;
		[Key("IconViewType")]
		public int IconViewType;
		[Key("PointOnFlag")]
		public int PointOnFlag;
		[Key("StoryFlag")]
		public int StoryFlag;
		//Why you gotta be like this...
		[Key("EventFinishFlag")]
		public int DeleteEventPointFlag;
		[Key("On")]
		public int[] On;
		[Key("Off")]
		public int[] Off;
		[Key("NpcOn")]
		public int[] NpcOn;
		[Key("NpcOff")]
		public int[] NpcOff;
		[Key("FlagOn")]
		public int[] FlagOn;
		[Key("FlagOff")]
		public int[] FlagOff;
		[Key("PointActive")]
		public bool PointActive;
		[Key("SceneId")]
		public int SceneId;
		[Key("PosX")]
		public float PosX;
		[Key("PosY")]
		public float PosY;
		[Key("PosZ")]
		public float PosZ;
	}
}
