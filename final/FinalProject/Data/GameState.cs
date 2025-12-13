using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace QuestTracker.Data
{
    public class GameState
    {
        [JsonInclude] private List<Quest> _quests;
        [JsonInclude] private int _totalPoints;
        [JsonInclude] private Character _player;

        public GameState()
        {
            _quests = new List<Quest>();
            _totalPoints = 0;
        }

        public List<Quest> GetQuests()
        {
            return _quests;
        }

        public int GetTotalPoints()
        {
            return _totalPoints;
        }
        public Character GetPlayer()
        {
            return _player;
        }

        public void SetPlayer(Character player)
        {
            _player = player;
        }

        public void AddQuest(Quest quest)
        {
            _quests.Add(quest);
        }

        public void AddPoints(int points)
        {
            _totalPoints = _totalPoints + points;
        }

        public void RecalculatePoints()
        {
            _totalPoints = 0;

            foreach (Quest q in _quests)
            {
                if (q.GetIsComplete())
                {
                    _totalPoints = _totalPoints + q.GetPoints();
                }
            }
        }

    }
}
