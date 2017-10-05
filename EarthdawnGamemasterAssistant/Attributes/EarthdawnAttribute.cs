namespace EarthdawnGamemasterAssistant.CharacterGenerator.Attributes
{
    public abstract class EarthdawnAttribute
    {
        public int Value { get; }
        public abstract string Name { get; }

        public EarthdawnAttribute(int value)
        {
            Value = value;
        }
    }
}