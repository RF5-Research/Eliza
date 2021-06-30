using MessagePack;
using System.Collections.Generic;

namespace Eliza.Model
{
    [MessagePackObject]
    public class SeedItemData : AmountItemData
    {
        public SeedItemData()
        {
            LevelAmount = new List<int>();
        }
    }
}
