namespace QuestTracker.Data
{
    public class BossQuest : Quest
    {
        private bool _bossDefeated;

        public BossQuest(string title, string description, int rewardXP)
            : base(title, description, rewardXP)
        {
            _bossDefeated = false;
        }

        public override void RecordProgress()
        {
            if (!_bossDefeated)
            {
                _bossDefeated = true;
                MarkComplete();
            }
        }

        public override string GetStatus()
        {
            return GetIsComplete() ? "[X] Boss Defeated" : "[ ] Boss Not Defeated";
        }
    }
}
