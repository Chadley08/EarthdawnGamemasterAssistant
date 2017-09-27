using System;
using System.Collections.Generic;
using System.Linq;

namespace EarthdawnGamemasterAssistant.Disciplines
{
    public class PhysicalDefenseAbilityRule : IAbilityRule
    {
        public PhysicalDefenseAbilityRule(string description, int bonusAmount)
        {
            Description = description;
            BonusAmount = bonusAmount;
        }

        public int BonusAmount { get; }
        public string Description { get; }
    }
}