namespace EarthdawnGamemasterAssistant.AbilityRules
{
    public class GeneralAbilityRule
    {
        public string Description { get; }
        public int BonusAmount { get; }
        public int CircleRequirement { get; }

        public GeneralAbilityRule(string description, int bonusAmount, int circleRequirement)
        {
            Description = description;
            BonusAmount = bonusAmount;
            CircleRequirement = circleRequirement;
        }
    }
}