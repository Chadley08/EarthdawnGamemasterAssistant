using EarthdawnGamemasterAssistant.Attributes;

namespace EarthdawnGamemasterAssistant.Talents
{
    public class Talent
    {
        public string Name { get; }
        public string Description { get; }
        public Attribute BaseAttribute { get; }
        public int Rank { get; }
        public ActionType Action { get; }
        public int Strain { get; }
        public bool SkillUse { get; }

        public Talent(
            string name,
            string description,
            Attribute baseAttribute,
            int rank,
            ActionType action,
            int strain,
            bool skillUse)
        {
            Name = name;
            Description = description;
            BaseAttribute = baseAttribute;
            Rank = rank;
            Action = action;
            Strain = strain;
            SkillUse = skillUse;
        }
    }
}