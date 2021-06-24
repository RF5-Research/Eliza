using static Eliza.Core.Serialization.Attributes;
using System;

namespace Eliza.Model
{
    public class WeatherData
	{
        public byte WeatherId;
        public byte WeatherDayId;
        public byte TodayRate;
        public byte TyphoonDayCount;
        public byte RuneyDayCount;
        public byte MeteorShowerDayCount;
        public byte NextWeatherDayId;
        [Length(Type = TypeCode.Byte)]
        public byte[] WeatherHour;

        //public byte WeatherId { get => weatherId; set => weatherId = value; }
        //public byte WeatherDayId { get => weatherDayId; set => weatherDayId = value; }
        //public byte TodayRate { get => todayRate; set => todayRate = value; }
        //public byte TyphoonDayCount { get => typhoonDayCount; set => typhoonDayCount = value; }
        //public byte RuneyDayCount { get => runeyDayCount; set => runeyDayCount = value; }
        //public byte MeteorShowerDayCount { get => meteorShowerDayCount; set => meteorShowerDayCount = value; }
        //public byte NextWeatherDayId { get => nextWeatherDayId; set => nextWeatherDayId = value; }
        //public byte[] WeatherHour { get => weatherHour; set => weatherHour = value; }
    }
}
