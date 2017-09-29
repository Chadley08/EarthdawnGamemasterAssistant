namespace EarthdawnGamemasterAssistant.AbilityRules
{
    public class SocialDefenseAbilityRule
    {
        public string Description { get; }
        public int BonusAmount { get; }
        public int CircleRequirement { get; }

        public SocialDefenseAbilityRule(string description, int bonusAmount, int circleRequirement)
        {
            Description = description;
            BonusAmount = bonusAmount;
            CircleRequirement = circleRequirement;
        }
    }
}