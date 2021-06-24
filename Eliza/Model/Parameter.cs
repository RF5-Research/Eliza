using MessagePack;
using System;

namespace Eliza.Model
{
    [MessagePackObject]
	public class Parameter
	{
        [Key(0)]
        public int MaxHp;
        [Key(1)]
        public int MaxRp;
        [Key(2)]
        public int Attack;
        [Key(3)]
        public int Defense;
        [Key(4)]
        public int MagicAttack;
        [Key(5)]
        public int MagicDefense;
        [Key(6)]
        public int Strength;
        [Key(7)]
        public int Intelligence;
        [Key(8)]
        public int Vitality;
        [Key(9)]
        public float AttackCritical;
        [Key(10)]
        public float AttackKnockBackRate;
        [Key(11)]
        public float AttackKnockBackTime;
        [Key(12)]
        public float AttackStun;
        [Key(13)]
        public float AttackPoison;
        [Key(14)]
        public float AttackSeal;
        [Key(15)]
        public float AttackParalysis;
        [Key(16)]
        public float AttackSleep;
        [Key(17)]
        public float AttackTire;
        [Key(18)]
        public float AttackSick;
        [Key(19)]
        public float AttackDeath;
        [Key(20)]
        public float AttackHpDrain;
        [Key(21)]
        public float DefenceFire;
        [Key(22)]
        public float DefenceWater;
        [Key(23)]
        public float DefenceEarth;
        [Key(24)]
        public float DefenceWind;
        [Key(25)]
        public float DefenceShine;
        [Key(26)]
        public float DefenceDark;
        [Key(27)]
        public float DefenceLove;
        [Key(28)]
        public float DefenceMu;
        [Key(29)]
        public float DefenceStunRate;
        [Key(30)]
        public float DefenceCritical;
        [Key(31)]
        public float DefenceKnockBackRate;
        [Key(32)]
        public float KnockbackTime;
        [Key(33)]
        public float DefencePoison;
        [Key(34)]
        public float DefenceSeal;
        [Key(35)]
        public float DefenceParalysis;
        [Key(36)]
        public float DefenceSleep;
        [Key(37)]
        public float DefenceTire;
        [Key(38)]
        public float DefenceSick;
        [Key(39)]
        public float DefenceDeath;
        [Key(40)]
        public float DefenceHpDrain;
        [Key(41)]
        public float SpeedRate;
        [Key(42)]
        public float AccelerationRate;
        [Key(43)]
        public float DecelerationRate;
        [Key(44)]
        public float RotateSpeedRate;
        [Key(45)]
        public float ChargeSpeed;
        [Key(46)]
        public float AttackLength;
    }
}
