namespace EarthdawnGamemasterAssistant.AbilityRules
{
    public class RecoveryTestAbilityRule
    {
        public string Description { get; }
        public int BonusAmount { get; }
        public int CircleRequirement { get; }

        public RecoveryTestAbilityRule(string description, int bonusAmount, int circleRequirement)
        {
            Description = description;
            BonusAmount = bonusAmount;
            CircleRequirement = circleRequirement;
        }
    }
}