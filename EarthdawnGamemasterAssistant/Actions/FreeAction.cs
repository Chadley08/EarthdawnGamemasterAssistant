namespace EarthdawnGamemasterAssistant.Actions
{
    public class FreeAction : ActionType
    {
        protected override ActionName _ActionName => ActionName.Free;
        public override string ToString() => "Free";
    }
}