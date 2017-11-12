namespace EarthdawnGamemasterAssistant.CharacterGenerator.Talents
{
    public class RankStepRule : IStepRule
    {
        public int CalculateStep(int talentRank, int attributeStep)
        {
            return talentRank;
        }
    }
}