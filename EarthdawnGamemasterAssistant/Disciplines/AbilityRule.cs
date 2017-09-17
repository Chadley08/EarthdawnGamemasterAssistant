namespace EarthdawnGamemasterAssistant.Disciplines
{
    public abstract class AbilityRule
    {
        public int CircleRequirement { get; }
        public int BonusAmount { get; }
        public string Description { get; }

        public AbilityRule(int circleRequirement, int bonusAmount, string description)
        {
            CircleRequirement = circleRequirement;
            BonusAmount = bonusAmount;
            Description = description;
        }
    }
}