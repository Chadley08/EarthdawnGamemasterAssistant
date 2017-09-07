using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using earthdawn_tabletop_player.Talents;

namespace EarthdawnGamemasterAssistant.Disciplines
{
    public class AirSailor : Discipline
    {
        protected AirSailor(int durabilityRating, Circle circle) : base(durabilityRating, circle)
        {
            
        }

        public static IReadOnlyList<Talent> DisciplineTalents = new List<Talent>()
        {
            new Talent("Avoid Blow", "", ActionType.Free, 1, true)
        };

        public static IReadOnlyList<Talent> NoviceTalentOptions = new List<Talent>()
        {
            
        };

        public static IReadOnlyList<Talent> JourneymanTalentOptions = new List<Talent>()
        {
            
        };
    }
}
