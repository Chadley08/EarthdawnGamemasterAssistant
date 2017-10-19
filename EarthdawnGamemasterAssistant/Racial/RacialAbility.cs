namespace EarthdawnGamemasterAssistant.CharacterGenerator.Racial
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
    }
}