using Eliza.Model.ItemFurniture;
using System.Collections.Generic;

namespace Eliza.Model.SaveData
{
    public class RF5FurnitureData
    {
        public int Unk1;
        public int Unk2;
        //They use a max, but they put it in the save file currently
        public List<FurnitureSaveData> FurnitureSaveData;
    }
}
