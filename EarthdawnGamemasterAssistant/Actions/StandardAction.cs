using EarthdawnGamemasterAssistant.Talents;

namespace EarthdawnGamemasterAssistant.Actions
{
    internal class StandardAction : ActionType
    {
        protected override ActionName _ActionName => ActionName.Standard;
        public override string ToString() => "Standard";
    }
}