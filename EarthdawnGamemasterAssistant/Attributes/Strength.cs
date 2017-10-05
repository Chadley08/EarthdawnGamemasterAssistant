namespace EarthdawnGamemasterAssistant.CharacterGenerator.Attributes
{
    public class Strength : EarthdawnAttribute
    {
        public Strength(int value) : base(value)
        {
        }

        public override string Name => "Str";
    }
}