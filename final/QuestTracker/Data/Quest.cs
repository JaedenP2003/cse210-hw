using System;

namespace QuestTracker.Data
{
    public abstract class Quest
    {
        private string _title;
        private string _description;
        private int _rewardXP;
        private bool _isComplete;

        public Quest(string title, string description, int rewardXP)
        {
            _title = title;
            _description = description;
            _rewardXP = rewardXP;
            _isComplete = false;
        }

        // Getters
        public string GetTitle()
        {
            return _title;
        }
        public string GetDescription()
        {
            return _description;
        }
        public int GetRewardXP()
        {
            return _rewardXP;
        }
        public bool GetIsComplete()
        {
            return _isComplete;
        }

        // Setter for completion
        protected void MarkComplete()
        {
            _isComplete = true;
        }

        public abstract void RecordProgress();
        public abstract string GetStatus();
    }
}
