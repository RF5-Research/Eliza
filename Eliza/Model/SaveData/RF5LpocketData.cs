using System.Collections.Generic;
using static Eliza.Core.Serialization.Attributes;

namespace Eliza.Model.SaveData
{
    public class RF5LpocketData
    {
        public bool SyncToCampEquip;
        public int QuickLastFocus;
        public int CampLastFocus;
        [Length(Size = 38)]
        public List<int> Unk;
        //public List<int> UIEMCategoriesCustomNo;
        //public List<int> UIEMQuckCategories;
    }
}