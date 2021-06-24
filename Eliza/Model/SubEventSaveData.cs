using MessagePack;

namespace Eliza.Model
{
    [MessagePackObject(keyAsPropertyName: true)]
    public class SubEventSaveData
    {
        public int ProgressingSubEventID;
    }
}
