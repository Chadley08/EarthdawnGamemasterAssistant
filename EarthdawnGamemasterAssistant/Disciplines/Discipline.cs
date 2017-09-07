namespace EarthdawnGamemasterAssistant.Disciplines
{
    public abstract class Discipline
    {
        public int DurabilityRating { get; }
        public Circle _Circle { get; }

        protected Discipline(int durabilityRating, Circle circle)
        {
            DurabilityRating = durabilityRating;
            _Circle = circle;
        }
    }
}