namespace EarthdawnGamemasterAssistant.Attributes
{
    public class Strength : Attribute
    {
        public Strength(int value) : base(value)
        {
        }

        public override string Name => "Strength";
    }
}