using System.Collections.Generic;
using earthdawn_tabletop_player.Talents;

namespace EarthdawnGamemasterAssistant.Disciplines
{
    public abstract class Discipline
    {
        protected int DurabilityRating { get; }
        protected Circle _Circle { get; }


        protected Discipline(int durabilityRating, Circle circle)
        {
            DurabilityRating = durabilityRating;
            _Circle = circle;
        }
    }
}