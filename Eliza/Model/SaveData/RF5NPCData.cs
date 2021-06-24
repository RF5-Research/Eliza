using System.Collections.Generic;

namespace Eliza.Model.SaveData
{
    public class RF5NPCData
    {
        public List<NpcSaveParameter> NpcSaveParameters;
        public NpcDateSaveParameter NpcDateSaveParam;
        public ChildSaveData ChildSaveDatas;
        public GiveBirthSaveParameter GiveBirthParams;
        public Dictionary<int, ItemStorageData> NpcHatCache;
    }
}
