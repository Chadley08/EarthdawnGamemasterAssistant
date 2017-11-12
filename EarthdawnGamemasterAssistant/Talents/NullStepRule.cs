namespace EarthdawnGamemasterAssistant.CharacterGenerator.Talents
{
    public class NullStepRule : IStepRule
    {
        public int CalculateStep(int talentRank, int attributeStep) => 0;
    }
}