using System.Collections.Generic;
using System.Linq;

namespace EarthdawnGamemasterAssistant.Disciplines
{
    internal class Archer : Discipline
    {
        public Archer(int circle) : base(5, circle, Abilities.ToList())
        {
        }

        public static IReadOnlyList<AbilityRule> Abilities = new List<AbilityRule>()
        {
            new PhysicalDefenseAbilityRule(2, 1, "Character gains +1 to physical defense")
        };

        public override string Name => "Archer";
    }
}