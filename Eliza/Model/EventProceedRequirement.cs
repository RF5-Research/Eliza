using MessagePack;

namespace Eliza.Model
{
    [MessagePackObject(keyAsPropertyName: true)]
    public class EventProceedRequirement
    {
        public int EventProceedType;
    }
}
