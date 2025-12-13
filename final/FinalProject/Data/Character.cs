using System;
using System.Text.Json.Serialization;

namespace QuestTracker.Data
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
    [JsonDerivedType(typeof(Warrior), "warrior")]
    [JsonDerivedType(typeof(Mage), "mage")]
    [JsonDerivedType(typeof(Rogue), "rogue")]
    public abstract class Character
    {
        [JsonInclude] protected string _name;
        [JsonInclude] protected int _level;
        [JsonInclude] protected int _experience;

        protected Character()
        {
        }

        public Character(string name)
        {
            _name = name;
            _level = 1;
            _experience = 0;
        }

        public string GetName() { return _name; }
        public int GetLevel() { return _level; }
        public int GetExperience() { return _experience; }

        public void AddExperience(int amount)
        {
            _experience = _experience + amount;
            CheckLevelUp();
        }

        protected void CheckLevelUp()
        {
            int required = _level * 100;

            while (_experience >= required)
            {
                _experience = _experience - required;
                _level = _level + 1;
                required = _level * 100;
            }
        }
    }
}
