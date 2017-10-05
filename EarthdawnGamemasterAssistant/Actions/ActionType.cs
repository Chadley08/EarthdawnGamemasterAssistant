namespace EarthdawnGamemasterAssistant.CharacterGenerator.Actions
{
    public abstract class ActionType
    {
        protected abstract ActionName _ActionName { get; }

        public new abstract string ToString();
    }
}