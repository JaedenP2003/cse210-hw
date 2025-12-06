using System;

namespace QuestTracker.Data
{
    public abstract class Character
    {
        private string _name;
        private int _level;
        private int _experience;

        public Character(string name)
        {
            _name = name;
            _level = 1;
            _experience = 0;
        }

        // Getters
        public string GetName()
        {
            return _name;
        }
        public int GetLevel()
        {
            return _level;
        }
        public int GetExperience()
        {
            return _experience;
        }

        // Setters
        public void SetName(string name)
        {
            _name = name;
        }

        public void AddExperience(int amount)
        {
            _experience += amount;
            while (_experience >= 100)
            {
                _experience -= 100;
                _level += 1;
            }
        }

        public abstract string GetClassName();
    }
}
