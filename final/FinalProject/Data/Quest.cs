using System;
using System.Text.Json.Serialization;

namespace QuestTracker.Data
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
    [JsonDerivedType(typeof(SimpleQuest), "simple")]
    [JsonDerivedType(typeof(CollectionQuest), "collection")]
    [JsonDerivedType(typeof(BossQuest), "boss")]
    public abstract class Quest
    {
        [JsonInclude] protected string _name;
        [JsonInclude] protected string _description;
        [JsonInclude] protected int _points;
        [JsonInclude] protected bool _isComplete;

        protected Quest()
        {
        }

        public Quest(string name, string description, int points)
        {
            _name = name;
            _description = description;
            _points = points;
            _isComplete = false;
        }

        public string GetName()
        {
            return _name;
        }

        public string GetDescription()
        {
            return _description;
        }

        public int GetPoints()
        {
            return _points;
        }

        public bool GetIsComplete()
        {
            return _isComplete;
        }

        public abstract void RecordProgress();
    }
}
