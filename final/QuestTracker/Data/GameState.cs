using System.Collections.Generic;

namespace QuestTracker.Data
{
    public class GameState
    {
        private Character _player;
        private List<Quest> _quests;

        public GameState()
        {
            _quests = new List<Quest>();
        }

        public Character GetPlayer()
        {
            return _player;
        }
        public void SetPlayer(Character player)
        {
            _player = player;
        }

        public List<Quest> GetQuests()
        {
            return _quests;
        }

        public void AddQuest(Quest quest)
        {
            _quests.Add(quest);
        }
    }
}
