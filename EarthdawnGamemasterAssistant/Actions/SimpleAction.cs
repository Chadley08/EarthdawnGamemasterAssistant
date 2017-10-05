namespace EarthdawnGamemasterAssistant.CharacterGenerator.Actions
{
    internal class SimpleAction : ActionType
    {
        protected override ActionName _ActionName => ActionName.Simple;

        public override string ToString() => "Simple";
    }
}