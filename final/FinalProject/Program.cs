using System;
using QuestTracker.Data;
using QuestTracker.Services;

namespace QuestTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            GameService game = new GameService();
            SaveLoadService saveLoad = new SaveLoadService();
            string saveFile = "savegame.json";

            CreateCharacter(game);
            SeedQuests(game);

            bool running = true;

            while (running)
            {
                Console.Clear();
                DisplayStatus(game);

                Console.WriteLine();
                Console.WriteLine("1. Record quest progress");
                Console.WriteLine("2. Save game");
                Console.WriteLine("3. Load game");
                Console.WriteLine("4. Add New Quest");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");

                string input = Console.ReadLine();

                if (input == "1")
                {
                    CompleteQuest(game);
                }
                else if (input == "2")
                {
                    saveLoad.SaveToFile(game.GetState(), saveFile);
                }
                else if (input == "3")
                {
                    GameState loaded = saveLoad.LoadFromFile(saveFile);
                    game = new GameService();
                    game.GetState().SetPlayer(loaded.GetPlayer());

                    foreach (Quest q in loaded.GetQuests())
                    {
                        game.GetState().AddQuest(q);
                    }
                    game.GetState().RecalculatePoints();
                }
                else if (input == "4")
                {
                    CreateQuest(game);
                }
                else if (input == "5")
                {
                    running = false;
                }
            }
        }

        static void CreateCharacter(GameService game)
        {
            Console.Write("Enter character name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Choose class:");
            Console.WriteLine("1. Warrior");
            Console.WriteLine("2. Mage");
            Console.WriteLine("3. Rogue");
            Console.Write("Choice: ");

            string choice = Console.ReadLine();
            Character player;
            
            if (choice == "2")
            {
                player = new Mage(name);
            }
            else if (choice == "3")
            {
                player = new Rogue(name);
            }
            else
            {
                player = new Warrior(name);
            }

            game.GetState().SetPlayer(player);
        }
        static void CreateQuest(GameService game)
        {
            Console.WriteLine("Select Quest Type:");
            Console.WriteLine("1. Simple Quest");
            Console.WriteLine("2. Collection Quest");
            Console.WriteLine("3. Boss Quest");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                CreateSimpleQuest(game);
            }
            else if (choice == "2")
            {
                CreateCollectionQuest(game);
            }
            else if (choice == "3")
            {
                CreateBossQuest(game);
            }
        }

        static void CreateSimpleQuest(GameService game)
        {
            Console.Write("Quest name: ");
            string name = Console.ReadLine();

            Console.Write("Description: ");
            string description = Console.ReadLine();

            Console.Write("Points: ");
            int points = int.Parse(Console.ReadLine());

            Quest q = new SimpleQuest(name, description, points);
            game.GetState().AddQuest(q);
        }

        static void CreateCollectionQuest(GameService game)
        {
            Console.Write("Quest name: ");
            string name = Console.ReadLine();

            Console.Write("Description: ");
            string description = Console.ReadLine();

            Console.Write("Points: ");
            int points = int.Parse(Console.ReadLine());

            Console.Write("How many items required? ");
            int required = int.Parse(Console.ReadLine());

            Quest q = new CollectionQuest(name, description, points, required);
            game.GetState().AddQuest(q);
        }

        static void CreateBossQuest(GameService game)
        {
            Console.Write("Quest name: ");
            string name = Console.ReadLine();

            Console.Write("Description: ");
            string description = Console.ReadLine();

            Console.Write("Points: ");
            int points = int.Parse(Console.ReadLine());

            Quest q = new BossQuest(name, description, points);
            game.GetState().AddQuest(q);
}

        static void SeedQuests(GameService game)
        {
            game.GetState().AddQuest(
            new SimpleQuest("First Steps", "Finish your first task", 10));

            game.GetState().AddQuest(
            new CollectionQuest("Collector", "Gather 3 items", 20, 3));

            game.GetState().AddQuest(
            new BossQuest("Big Bad", "Defeat the boss", 50));
        }
        static void DisplayStatus(GameService game)
        {
            Character c = game.GetState().GetPlayer();

            if (c == null)
            {
                Console.WriteLine("No character created.");
                return;
            }

            Console.WriteLine("Name: " + c.GetName());
            Console.WriteLine("Level: " + c.GetLevel());
            Console.WriteLine("XP: " + c.GetExperience());
            Console.WriteLine("Total Points: " + game.GetState().GetTotalPoints());
            Console.WriteLine();

            var quests = game.GetState().GetQuests();

            for (int i = 0; i < quests.Count; i++)
            {
                Quest q = quests[i];
                string progress = "";

                if (q is CollectionQuest)
                {
                    CollectionQuest cq = (CollectionQuest)q;
                    progress = " [" + cq.GetCurrentCount() + "/" + cq.GetRequiredCount() + "]";
                }

                Console.WriteLine(
                    i + ". " +
                    q.GetName() + progress +
                    " (Complete: " + q.GetIsComplete() + ")");
            }
        }

        static void DisplayQuests(GameService game)
        {
            List<Quest> quests = game.GetState().GetQuests();

            for (int i = 0; i < quests.Count; i++)
            {
                Quest q = quests[i];

                Console.Write((i + 1) + ". ");
                Console.Write(q.GetName() + " - ");

                if (q is CollectionQuest)
                {
                    CollectionQuest cq = (CollectionQuest)q;
                    Console.WriteLine(
                        cq.GetCurrentCount() + "/" + cq.GetRequiredCount()
                    );
                }
                else if (q.GetIsComplete())
                {
                    Console.WriteLine("Completed");
                }
                else
                {
                    Console.WriteLine("Incomplete");
                }
            }
        }

        static void CompleteQuest(GameService game)
        {
            Console.Write("Enter quest number: ");
            string input = Console.ReadLine();

            int index;

            if (int.TryParse(input, out index))
            {
                game.CompleteQuest(index);
            }
        }
    }
}