namespace QuestTracker.Data
{
    public class CollectionQuest : Quest
    {
        private int _goalCount;
        private int _currentCount;

        public CollectionQuest(string title, string description, int rewardXP, int goalCount)
            : base(title, description, rewardXP)
        {
            _goalCount = goalCount;
            _currentCount = 0;
        }

        public override void RecordProgress()
        {
            if (GetIsComplete()) return;

            _currentCount++;

            if (_currentCount >= _goalCount)
            {
                MarkComplete();
            }
        }

        public override string GetStatus()
        {
            return GetIsComplete()
                ? $"[X] Completed {_goalCount}/{_goalCount}"
                : $"[ ] Completed {_currentCount}/{_goalCount}";
        }
    }
}
