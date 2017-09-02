using System;
using System.Diagnostics;

namespace EarthdawnGamemasterAssistant.Attributes
{
    public class Attribute
    {
        public int Value { get; }

        public Attribute(int value)
        {
            Value = value;
        }
    }
}