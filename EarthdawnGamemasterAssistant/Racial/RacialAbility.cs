namespace EarthdawnGamemasterAssistant.Racial
{
    public abstract class RacialAbility
    {
        public string Name { get; }
        public string Description { get; }

        protected RacialAbility(string name, string description)
        {
            Name = name;
            Description = description;
        }

        protected abstract void Apply();
    }
}