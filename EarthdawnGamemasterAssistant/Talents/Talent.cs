using EarthdawnGamemasterAssistant.CharacterGenerator.Actions;
using EarthdawnGamemasterAssistant.CharacterGenerator.Attributes;

namespace EarthdawnGamemasterAssistant.CharacterGenerator.Talents
{
    public class Talent
    {
        public string Name { get; }
        public string Description { get; }
        public EarthdawnAttribute BaseEarthdawnAttribute { get; }
        public int Rank { get; private set; }
        public ActionType Action { get; }
        public int Strain { get; }
        public bool SkillUse { get; }

        public Talent(
            string name,
            string description,
            EarthdawnAttribute baseEarthdawnAttribute,
            int rank,
            ActionType action,
            int strain,
            bool skillUse)
        {
            Name = name;
            Description = description;
            BaseEarthdawnAttribute = baseEarthdawnAttribute;
            Rank = rank;
            Action = action;
            Strain = strain;
            SkillUse = skillUse;
        }
    }
}