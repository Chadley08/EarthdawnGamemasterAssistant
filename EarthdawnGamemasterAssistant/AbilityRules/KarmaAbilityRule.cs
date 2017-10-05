namespace EarthdawnGamemasterAssistant.CharacterGenerator.AbilityRules
{
    public class KarmaAbilityRule
    {
        public string Description { get; }
        public int BonusAmount { get; }
        public int CircleRequirement { get; }

        public KarmaAbilityRule(string description, int bonusAmount, int circleRequirement)
        {
            Description = description;
            BonusAmount = bonusAmount;
            CircleRequirement = circleRequirement;
        }
    }
}