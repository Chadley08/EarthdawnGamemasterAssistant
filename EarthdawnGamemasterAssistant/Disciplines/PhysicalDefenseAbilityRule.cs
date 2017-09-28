using System;
using System.Collections.Generic;
using System.Linq;

namespace EarthdawnGamemasterAssistant.Disciplines
{
    public class PhysicalDefenseAbilityRule
    {
        public PhysicalDefenseAbilityRule(string description, int bonusAmount, int circleRequirement)
        {
            Description = description;
            BonusAmount = bonusAmount;
            CircleRequirement = circleRequirement;
        }

        public int BonusAmount { get; }
        public int CircleRequirement { get; }
        public string Description { get; }
    }
}