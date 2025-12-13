namespace QuestTracker.Data
{
    public class BossQuest : Quest
    {
        public BossQuest(string name, string description, int points)
        : base(name, description, points)
        {
        }
        
        public BossQuest() : base()
        {
        }

        public override void RecordProgress()
        {
        _isComplete = true;
        }
    }
}
