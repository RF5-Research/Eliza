using MessagePack;
using System.Collections.Generic;

namespace Eliza.Model
{
	[MessagePackObject(keyAsPropertyName: true)]
    public class EventData
    {
		public int EventId;
		public int EventState;
		public int OrderId;
		public int CurrentStep;
		public int CurrentReservedStep;
		public int NextStep;
		public int CurrentNpcEventType;
		public string CurrentNpcEventPath;
		public int CurrentTargetEventStep;
		public List<SubEventStep> SubEventSteps;
	}
}
