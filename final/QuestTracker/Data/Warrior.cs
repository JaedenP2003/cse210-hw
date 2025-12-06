namespace QuestTracker.Data
{
    public class Warrior : Character
    {
        public Warrior(string name) : base(name) {}

        public override string GetClassName()
        {
            return "Warrior";
        }
    }
}
