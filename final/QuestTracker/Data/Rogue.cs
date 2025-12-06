namespace QuestTracker.Data
{
    public class Rogue : Character
    {
        public Rogue(string name) : base(name) {}

        public override string GetClassName()
        {
            return "Rogue";
        }
    }
}
