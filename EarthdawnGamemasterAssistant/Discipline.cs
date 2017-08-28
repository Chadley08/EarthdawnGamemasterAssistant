namespace EarthdawnGamemasterAssistant
{
    public class Discipline
    {
        public int DurabilityRating { get; }
        public Circle _Circle { get; }

        public Discipline(int durabilityRating, Circle circle)
        {
            DurabilityRating = durabilityRating;
            _Circle = circle;
        }
    }
}