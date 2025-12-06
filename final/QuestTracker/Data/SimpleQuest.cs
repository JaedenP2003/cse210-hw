namespace QuestTracker.Data
{
    public class SimpleQuest : Quest
    {
        public SimpleQuest(string title, string description, int rewardXP)
            : base(title, description, rewardXP)
        {
        }

        public override void RecordProgress()
        {
            MarkComplete();
        }

        public override string GetStatus()
        {
            return GetIsComplete() ? "[X] Complete" : "[ ] Not Complete";
        }
    }
}
