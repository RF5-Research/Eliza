using MessagePack;

namespace Eliza.Model
{
    [MessagePackObject(keyAsPropertyName: true)]
	public class IntArray
	{
		public int[] datas;
	}

}
