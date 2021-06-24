using MessagePack;

namespace Eliza.Model
{
    [MessagePackObject]
    public class FoodItemData : SynthesisItemData
    {
        [Key(3)]
        public bool IsArrange;
    }
}
