using MessagePack;
using System.Collections.Generic;

namespace Eliza.Model
{
	[MessagePackObject(keyAsPropertyName: true)]
	public class EventSaveParameter
	{
		public int CurrentEventId;
		public int CurrentEventStep;
		public bool IsTalking;
		public int SelectMenuGroupId;
		public bool IsSelectMenu;
		public int TargetNpcId;
		public int[] OrderNpcIds;
		public string ForceScriptName;
		public bool ForceEvent;
		public int orderOccuredId;
		public EventScheduleData[] EventScheduleDatas;
        public int bythewayMenuCommandNo;
        public int bythewayEventStep;
        public bool Is1stBytheWay;
        public int partnerMenuCommandNo;
        public int partnerEventStep;
        public int eventValue;
        public bool UseRetentionEventType;
        public List<EventUnlockFlagData> ReservedEventStartPoints;
        public int NowPlace;
        public int FlagTalkIndex;
        public bool IsSleepScriptCalled;
        public bool IsWakeUpReserve;
        public bool[] EventCheckTypeFlag;
        public int[] EventCheckType;
        public List<EventCheckId> EventCheckIds;
        public int NowType;
        public int[] LastYearFesVictoryNpcId;
        public bool SP4CharaOn;
    }
}
