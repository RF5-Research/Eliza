using MessagePack;

namespace Eliza.Model
{
	[MessagePackObject(keyAsPropertyName: true)]
    public class EventTimer
    {
		public int Year;
		public int Season;
		public int Week;
		public int Day;
		public int Hour;
		public int Minutes;
		public int TimeZone;
		public int Weather;
	}
}
