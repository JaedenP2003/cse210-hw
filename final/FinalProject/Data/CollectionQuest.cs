using System;
using System.Text.Json.Serialization;

namespace QuestTracker.Data
{
    public class CollectionQuest : Quest
    {
        [JsonInclude] private int _requiredCount;
        [JsonInclude] private int _currentCount;

        public CollectionQuest() : base()
        {
        }
        public CollectionQuest(string name, string description, int points, int requiredCount)
        : base(name, description, points)
        {
            _requiredCount = requiredCount;
            _currentCount = 0;
        }

        public int GetCurrentCount()
        {
            return _currentCount;
        }

        public int GetRequiredCount()
        {
            return _requiredCount;
        }

        public override void RecordProgress()
        {
            if (_isComplete)
            {
                return;
            }

            _currentCount = _currentCount + 1;

            if (_currentCount >= _requiredCount)
            {
                _isComplete = true;
            }
        }
    }
}
