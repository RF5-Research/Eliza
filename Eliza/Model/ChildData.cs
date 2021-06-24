using MessagePack;
using System;

namespace Eliza.Model
{
    [MessagePackObject(keyAsPropertyName: true)]
	[Serializable]
	public class ChildData
	{
		public string Name;
		public bool IsMale;
		public int Personality;
		public int BirthDay;
	}
}
