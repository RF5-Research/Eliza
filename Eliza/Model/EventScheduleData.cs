using MessagePack;
using System.Collections.Generic;

namespace Eliza.Model
{
	[MessagePackObject(keyAsPropertyName: true)]
    public class EventScheduleData
    {
		public int EventId;
		public int EventStep;
        public EventTimer[] StartTime;
        public EventTimer[] EndTime;
        public int JoinNpcNumMin;
        public int JoinNpcNumMax;
        public IntArray[] JoinNpcs;
        public IntArray[] JoinRateNpcs;
        public List<int> DecideJoinNpcs;
        public List<int> NpcScoreResults;
        public EventData[] NpcEventDatas;
        [IgnoreMember]
        public EventProceedRequirement[] EventProceedRequirement;
    }
}
