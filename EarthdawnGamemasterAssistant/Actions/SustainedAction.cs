namespace EarthdawnGamemasterAssistant.CharacterGenerator.Actions
{
    internal class SustainedAction : ActionType
    {
        protected override ActionName _ActionName => ActionName.Sustained;

        public override string ToString() => "Sustained";
    }
}