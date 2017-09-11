namespace EarthdawnGamemasterAssistant.Disciplines
{
    public class AbilityRule
    {
        public int CircleRequirement { get; }
        public CharacteristicBonus BonusType { get; }
        public int BonusAmount { get; }
        public string Description { get; }

        public AbilityRule(int circleRequirement, CharacteristicBonus bonusType, int bonusAmount, string description)
        {
            CircleRequirement = circleRequirement;
            BonusType = bonusType;
            BonusAmount = bonusAmount;
            Description = description;
        }
    }
}