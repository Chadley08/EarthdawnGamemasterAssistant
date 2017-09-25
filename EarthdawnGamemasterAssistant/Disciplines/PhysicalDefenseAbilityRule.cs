using System;

namespace EarthdawnGamemasterAssistant.Disciplines
{
    public class PhysicalDefenseAbilityRule
    {
        private readonly int BonusAmount;
        public string Description { get; }

        public PhysicalDefenseAbilityRule(string description, int bonusAmount)
        {
            BonusAmount = bonusAmount;
            Description = description;
        }
    }
}