namespace EarthdawnGamemasterAssistant.CharacterGenerator.Actions
{
    public class NullAction : ActionType
    {
        protected override ActionName _ActionName => ActionName.NotApplicable;

        public override string ToString() => "N/A";
    }
}