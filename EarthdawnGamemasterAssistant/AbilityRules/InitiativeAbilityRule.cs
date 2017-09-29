namespace EarthdawnGamemasterAssistant.AbilityRules
{
    public class InitiativeAbilityRule
    {
        public string Description { get; }
        public int BonusAmount { get; }
        public int CircleRequirement { get; }

        public InitiativeAbilityRule(string description, int bonusAmount, int circleRequirement)
        {
            Description = description;
            BonusAmount = bonusAmount;
            CircleRequirement = circleRequirement;
        }
    }
}