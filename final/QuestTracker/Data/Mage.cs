namespace QuestTracker.Data
{
    public class Mage : Character
    {
        public Mage(string name) : base(name) {}

        public override string GetClassName()
        {
            return "Mage";
        }
    }
}
