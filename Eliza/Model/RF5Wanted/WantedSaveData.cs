using MessagePack;

namespace Eliza.Model.RF5Wanted
{
    [MessagePackObject]
    public class WantedSaveData
    {
        [Key(0)]
        public int GeneratedTime;
        [Key(1)]
        public int Seed;
        [Key(2)]
        public bool Accepted;
        [Key(3)]
        public int AcceptedID;
        [Key(4)]
        public bool Finished;
        [Key(5)]
        public int AcceptedSeed;
        [Key(6)]
        public int RandomDataNo;
        [Key(7)]
        public bool[] firstCompleted;
        [Key(8)]
        public bool[] todayCompleted;
        [Key(9)]
        public int finishedCount;
        [Key(10)]
        public int score;
    }
}