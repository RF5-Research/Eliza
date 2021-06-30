using MessagePack;
using System.Collections.Generic;

namespace Eliza.Model
{
	[MessagePackObject]
    public class EquipItemData : SynthesisItemData
    {
        [Key(3)]
        public int[] AddedItems;
        [Key(4)]
        public int[] ArrangeItems;
        [Key(5)]
        public int ArrangeOverride;
        [Key(6)]
        public int BaseLevel;
        [Key(7)]
        public int SozaiLevel;
        [Key(8)]
        public int DualWorkSmithBonusType;
        [Key(9)]
        public int DualWorkLoveLevel;
        [Key(10)]
        public int DualWorkActor;
        [Key(11)]
        public int DualWorkParam;
        [IgnoreMember]
		private static Dictionary<int, int> SameItemNum;

        public EquipItemData()
        {
            AddedItems = new int[0];
            ArrangeItems = new int[0];
            SourceItems = new int[0];
        }
	}
}