using MessagePack;

namespace Eliza.Model
{
    [MessagePackObject(keyAsPropertyName: true)]
	public class GiveBirthSaveParameter
	{
		public int Targetdays;
		public int NowType;
	}
}
