namespace Eliza.Model.SaveData
{
    public class RF5EventData
    {
        public EventSaveParameter EventSaveParameter;
        public SaveFlagStorage SaveFlag;
        public SubEventSaveData SubEventSaveDatas;
        // Add this to the UI
        public SaveScenarioSupport ScenarioSupport;
        public int MainScenarioStep;
        public int[] PresentSendActorList;
        public int[] PresentRecvActorList;
        public bool IsStartFishing;
        public int[] FesJoinActorList;
        public int[] FesVisitorActorList;
        public FesNpcScore[] FesNpcScoreList;
        public int IsCalcFesId;
        public int VictoryCandidateNpcId;
        public int JudgeChildId;
        public int[] FishTypeList;
    }
}
