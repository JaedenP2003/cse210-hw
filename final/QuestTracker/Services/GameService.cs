using System;
using System.Collections.Generic;
using QuestTracker.Data;

namespace QuestTracker.Services
{
    public class GameService
    {
        private readonly GameState _state;

        public GameService()
        {
            _state = new GameState();
        }

        public GameState GetState()
        {
            return _state;
        }

        // Create a character by type (uses constructors from Data classes)
        public void CreateCharacter(string name, string type)
        {
            if (string.IsNullOrWhiteSpace(type)) type = "Warrior";

            Character c;
            switch (type.Trim().ToLower())
            {
                case "mage":
                    c = new Mage(name);
                    break;
                case "rogue":
                    c = new Rogue(name);
                    break;
                default:
                    c = new Warrior(name);
                    break;
            }

            _state.SetPlayer(c);
        }

        // Add demo quests for testing
        public void AddSampleQuests()
        {
            _state.AddQuest(new SimpleQuest("Run the Gauntlet", "Finish the gauntlet", 100));
            _state.AddQuest(new CollectionQuest("Collect Herbs", "Gather 3 herbs", 20, 3));
            _state.AddQuest(new BossQuest("Defeat Shadowlord", "Defeat the Shadowlord boss", 300));
        }

        // Record progress / complete quest by index.
        // Returns XP awarded (0 if none)
        public int CompleteQuest(int index)
        {
            var quests = _state.GetQuests();
            if (index < 0 || index >= quests.Count) return 0;

            Quest q = quests[index];

            // Remember previous completion state so we only award XP on transition
            bool wasComplete = q.GetIsComplete();

            // Polymorphic call into the quest
            q.RecordProgress();

            bool nowComplete = q.GetIsComplete();
            int awarded = 0;

            if (!wasComplete && nowComplete)
            {
                awarded = q.GetRewardXP();
            }

            // Award XP to player if applicable
            var player = _state.GetPlayer();
            if (player != null && awarded > 0)
            {
                player.AddExperience(awarded);
            }

            return awarded;
        }

        // Add a single quest
        public void AddQuest(Quest quest)
        {
            _state.AddQuest(quest);
        }

        // Reset everything (for testing)
        public void ResetState()
        {
            _state.SetPlayer(null);
            var list = _state.GetQuests();
            list.Clear();
        }
    }
}
