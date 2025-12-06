using System;
using System.IO;
using System.Text.Json;
using QuestTracker.Data;

namespace QuestTracker.Services
{
    public class SaveLoadService
    {
        private readonly string _file = "gamestate.json";

        public SaveLoadService()
        {
        }

        
        public void Save(GameState state, string filename = null)
        {
            try
            {
                string path = filename ?? _file;
                var options = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(state, options);
                File.WriteAllText(path, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Save failed: {ex.Message}");
            }
        }


        public GameState Load(string filename = null)
        {
            try
            {
                string path = filename ?? _file;
                if (!File.Exists(path)) return new GameState();

                string json = File.ReadAllText(path);
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                GameState state = JsonSerializer.Deserialize<GameState>(json, options);
                return state ?? new GameState();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Load failed: {ex.Message}");
                return new GameState();
            }
        }
    }
}
