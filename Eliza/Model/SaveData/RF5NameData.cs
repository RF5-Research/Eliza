using static Eliza.Core.Serialization.Attributes;

namespace Eliza.Model.SaveData
{
    public class RF5NameData
    {
		[Length(Max = 32)]
		public string Name_Farm_Soil;
		[Length(Max = 32)]
		public string Name_Farm_Fire;
		[Length(Max = 32)]
		public string Name_Farm_Ice;
		[Length(Max = 32)]
		public string Name_Farm_Wind;
		[Length(Max = 32)]
		public string Name_Farm_Ground;
		[Length(Max = 32)]
		public string Name_FarmPet_Soil_A;
		[Length(Max = 32)]
		public string Name_FarmPet_Soil_B;
		[Length(Max = 32)]
		public string Name_FarmPet_Fire_A;
		[Length(Max = 32)]
		public string Name_FarmPet_Fire_B;
		[Length(Max = 32)]
		public string Name_FarmPet_Ice_A;
		[Length(Max = 32)]
		public string Name_FarmPet_Ice_B;
		[Length(Max = 32)]
		public string Name_FarmPet_Wind_A;
		[Length(Max = 32)]
		public string Name_FarmPet_Wind_B;
		[Length(Max = 32)]
		public string Name_FarmPet_Ground_A;
		[Length(Max = 32)]
		public string Name_FarmPet_Ground_B;
	}
}