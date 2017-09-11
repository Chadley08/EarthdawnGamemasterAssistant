namespace EarthdawnGamemasterAssistant.Attributes
{
    public class Toughness : Attribute
    {
        public Toughness(int value) : base(value)
        {
        }

        public override string Name => "Toughness";
    }
}