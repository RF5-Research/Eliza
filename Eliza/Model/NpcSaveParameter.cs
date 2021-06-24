using MessagePack;
using System.Collections.Generic;
using UnityEngine;

namespace Eliza.Model
{
	[MessagePackObject(keyAsPropertyName: true)]
	public class NpcSaveParameter
	{
		public Vector3 SavePosition;
		public Quaternion SaveRotation;
		public bool forceDisabled;
		public bool isShortPlay;
		public int AnimationState;
		public bool AnimationSitting;
		public int NpcGroupId;
		public int CurrentFieldPlaceId;
		public int CurrentLifecycleState;
		public int CurrentPlace;
		public int RotatePatternNumber;
		public bool IsTalking;
		public int TodayTalkCount;
		public int NowEventId;
		public int Home;
		public int Job;
		public bool IsPartner;
		public bool IsSpouses;
		public bool IsLover;
		public bool IsRefused;
		public bool IsJealousy;
		public bool IsDateRefrain;
		public bool IsExclamation;
		public int AngryStep;
		public int LovePoint;
		public int DatingNum;
		public int PresentCount;
		public int NickNameToPlayerId;
		public int NickNameFromPlayerId;
		public int WeddingAnniversary;
		public List<int> PresentItemTypes;
		public bool IsVoiceSleepPlayed;
		public bool IsVoiceGreeted;
		public long[] TalkedTime;
		public int FriendlyMilestoneTalk;
		public int ChatTalkLv;
		public int ChatTalkCount;
		public int ChatTalkLotteryType;
		public int ChatTalkLotteryID;
		public int HomeTalkedLv;
		public int ModelType;
		public int LoveStroyState;
		public int FlowerFesDateNum;
		public bool IsDateReserved;
		public int dateDay;
	}
}
