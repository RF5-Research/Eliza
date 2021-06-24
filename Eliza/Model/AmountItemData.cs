using MessagePack;
using System.Collections.Generic;

namespace Eliza.Model
{
    [MessagePackObject]
    public class AmountItemData : ItemData
    {
        [Key(1)]
        public List<int> LevelAmount;
    }
}
