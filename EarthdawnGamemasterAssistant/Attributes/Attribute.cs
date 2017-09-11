using System.Collections.Specialized;

namespace EarthdawnGamemasterAssistant.Attributes
{
    public abstract class Attribute
    {
        public int Value { get; }
        public abstract string Name { get; }

        public Attribute(int value)
        {
            Value = value;
        }
    }
}