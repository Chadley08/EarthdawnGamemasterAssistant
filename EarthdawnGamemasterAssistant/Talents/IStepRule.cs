namespace EarthdawnGamemasterAssistant.CharacterGenerator.Talents
{
    public interface IStepRule
    {
        int CalculateStep(int talentRank, int attributeStep);
    }
}