namespace EarthdawnGamemasterAssistant.CharacterGenerator.Talents
{
    public class RankPlusAttributeStepRule : IStepRule
    {
        public int CalculateStep(int talentRank, int attributeStep)
        {
            return talentRank + attributeStep;
        }
    }
}