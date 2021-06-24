using Eliza.Model.Farm;
using Eliza.Model.MonsterHut;
using System.Collections.Generic;
using static Eliza.Core.Serialization.Attributes;

namespace Eliza.Model.SaveData
{
    public class RF5FarmData
    {
        [MessagePackList]
        public bool[] FirstVisitFarm;
		[MessagePackList]
		public int[] FarmSizeLevels;
		[MessagePackList]
		public FarmCropData[] FarmCropDatas;
		[MessagePackList]
		public int[] CrystalUseCounts;
		[MessagePackList]
		public RF4_CROP_STATE[] Crop;
		[MessagePackList]
		public RF4_SOIL_INFO[] Soil;
		[MessagePackList]
		public bool[] MonsterHutReleaseFlags;
		[MessagePackList]
		public int[] HarvestCount;
		[MessagePackList]
		public List<int> ItemHarvestIdList;
		[MessagePackList]
		public MonsterHutSaveData[] MonsterHutSaveDatas;
	}
}
