using EarthdawnGamemasterAssistant.Talents;
using System.Collections.Generic;

namespace EarthdawnGamemasterAssistant.Disciplines
{
    public class AirSailor : Discipline
    {
        protected AirSailor(int durabilityRating, Circle circle) : base(durabilityRating, circle)
        {
        }

        public static IReadOnlyList<Talent> DisciplineTalents = new List<Talent>()
        {
            new Talent("Avoid Blow", "", new FreeAction(), 1, true)
        };

        public static IReadOnlyList<Talent> NoviceTalentOptions = new List<Talent>()
        {
        };

        public static IReadOnlyList<Talent> JourneymanTalentOptions = new List<Talent>()
        {
        };
    }
}