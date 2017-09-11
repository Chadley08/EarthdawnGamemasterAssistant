using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using EarthdawnGamemasterAssistant.Annotations;

namespace EarthdawnGamemasterAssistant.Disciplines
{
    public abstract class Discipline
    {
        public int DurabilityRating { get; }
        public Circle _Circle { get; }
        public List<AbilityRule> AbilityRules { get; }

        protected Discipline(int durabilityRating, Circle circle, List<AbilityRule> abilityRules)
        {
            DurabilityRating = durabilityRating;
            _Circle = circle;
            AbilityRules = abilityRules;
        }
    }
}