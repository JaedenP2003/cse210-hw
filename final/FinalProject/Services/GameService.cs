using System;
using System.Collections.Generic;
using QuestTracker.Data;

namespace QuestTracker.Services
{
    public class GameService
    {
        private GameState _state;

        public GameService()
        {
            _state = new GameState();
        }

        public GameState GetState()
        {
            return _state;
        }

        public void CompleteQuest(int index)
        {
            List<Quest> quests = _state.GetQuests();

            if (index < 0 || index >= quests.Count)
            {
                return;
            }

            Quest q = quests[index];

            bool wasComplete = q.GetIsComplete();

            q.RecordProgress();

            if (!wasComplete && q.GetIsComplete())
            {
                _state.AddPoints(q.GetPoints());

                Character player = _state.GetPlayer();
                if (player != null)
                {
                    player.AddExperience(q.GetPoints());
                }
            }
        }
    }
}
