using static Eliza.Core.Serialization.Attributes;

namespace Eliza.Model.SaveData
{
    public class SaveScenarioSupport
    {
        [Length(Size = 24)]
        public int[] m_talked;
    }
}