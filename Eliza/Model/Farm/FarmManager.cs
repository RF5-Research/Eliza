using MessagePack;

namespace Eliza.Model.Farm
{
    [MessagePackObject]
	public class RF4_CROP_STATE
	{
		// Fields
		[Key(0)]
		public RF4_CROP_STATE_INFO info;
		[Key(1)]
		public RF4_MCROP_INFO pMcrop;
		[Key(2)]
		public int pSoil;
		[Key(3)]
		public int flag;
		[Key(4)]
		public byte size;
		[Key(5)]
		public int crop_grow_state;
		[Key(6)]
		public byte die_flag;
		[Key(7)]
		public bool disp_cul;
		[Key(8)]
		public bool disp_cul_w;
		[Key(9)]
		public byte farm_id;
	}

	[MessagePackObject]
	public class RF4_CROP_STATE_INFO
    {
		[Key(0)]
		public BitVector32Int csi0;
		[Key(1)]
		public BitVector32Int csi1;
		[Key(2)]
		public BitVector32Int csi2;
		[Key(3)]
		public BitVector32Int csi3;
		[Key(4)]
		public int cell_id;
	}

	[MessagePackObject]
	public class RF4_MCROP_INFO
    {
		[Key(0)]
		public int enable;
		[Key(1)]
		public int mcrop_map_id;
		[Key(2)]
		public int mcrop_hp;
	}

	[MessagePackObject]
	public class RF4_SOIL_INFO
    {
		[Key(0)]
		public BitVector32Int SI0;
		[Key(1)]
		public BitVector32Int SI1;
		[Key(2)]
		public BitVector32Int SI2;
		[Key(3)]
		public BitVector32Int SI3;
	}
}
