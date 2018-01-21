using EarthdawnGamemasterAssistant.CharacterGenerator.Actions;
using EarthdawnGamemasterAssistant.CharacterGenerator.Attributes;

namespace EarthdawnGamemasterAssistant.CharacterGenerator.Talents
{
    public class NullTalent : Talent
    {
        public NullTalent() : base("", "", new NullAttribute(), 0, new NullStepRule(), new NullAction(), 0, false, "")
        {
        }
    }
}