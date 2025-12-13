namespace QuestTracker.Data
{
    public class SimpleQuest : Quest
    {
        public SimpleQuest() : base()
        {
        }
        
        public SimpleQuest(string name, string description, int points)
            : base(name, description, points)
        {
        }

        public override void RecordProgress()
        {
            _isComplete = true;
        }
    }
}