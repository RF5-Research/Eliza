using Eliza.Model.Field;
using System.Numerics;

namespace Eliza.Model.SaveData
{
    public class RF5WorldData
    {
		public byte DifficultyValue;
        public int ScenarioStoppedTime;
        public int MapId;
        public Vector3 Position;
        public Vector3 RotationEuler;
        public int InGameTimeElapsedTime;
        public WeatherData WeatherData;
        public uint ShopRandSeedFix;
        public uint ShopRandSeed;
        public int ShopSeedGenerateDay;
        public int LastShippingDay;
        public int LastPlaceId;
        public int LastSleepTime;
        public MiningPointSaveData[] MiningPointSaveDatas;
        public RewardBoxSaveData RewardBoxSaveData;
        public SaveFlagStorage ItemSpawnFlag;
        public SaveFlagStorage TreasureFlag;
        public SaveFlagStorage GimmickFlag;
        public int SeedPointElapsedDay;
        public int SeedPointMonsterAddedCount;
        public float SeedSupportCoolTime;
        public int[] MeteorPosition;
        // I'm not sure what this is atm. Placeholder for meteor maybe?
        public int unk1;
        public int OffsetFiveYearAgo;
        public int PunchCount;
    }
}
