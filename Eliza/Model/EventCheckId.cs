using MessagePack;

namespace Eliza.Model
{
	[MessagePackObject(keyAsPropertyName: true)]
	public class EventCheckId
    {
		public int CheckTriggerType;
		public int CheckTriggerId;
		public string CheckScriptName;
		public string CheckEnemyName;
	}
}
