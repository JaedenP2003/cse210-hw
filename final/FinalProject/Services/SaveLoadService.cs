using System;
using System.IO;
using System.Text.Json;
using QuestTracker.Data;

namespace QuestTracker.Services
{
    public class SaveLoadService
    {
        private JsonSerializerOptions _options;

        public SaveLoadService()
        {
            _options = new JsonSerializerOptions();
            _options.IncludeFields = true;
            _options.WriteIndented = true;
        }

        public void SaveToFile(GameState state, string fileName)
        {
            string json = JsonSerializer.Serialize(state, _options);
            File.WriteAllText(fileName, json);
        }

        public GameState LoadFromFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                return new GameState();
            }

            string json = File.ReadAllText(fileName);
            GameState state =
                JsonSerializer.Deserialize<GameState>(json, _options);

            if (state == null)
            {
                return new GameState();
            }

            return state;
        }
    }
}

