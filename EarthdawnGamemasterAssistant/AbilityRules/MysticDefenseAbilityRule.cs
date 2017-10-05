namespace EarthdawnGamemasterAssistant.CharacterGenerator.AbilityRules
{
    public class MysticDefenseAbilityRule
    {
        public string Description { get; }
        public int BonusAmount { get; }
        public int CircleRequirement { get; }

        public MysticDefenseAbilityRule(string description, int bonusAmount, int circleRequirement)
        {
            Description = description;
            BonusAmount = bonusAmount;
            CircleRequirement = circleRequirement;
        }
    }
}