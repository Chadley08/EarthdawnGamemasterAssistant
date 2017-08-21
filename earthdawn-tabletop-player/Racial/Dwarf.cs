using System.Collections.Generic;

namespace earthdawn_tabletop_player.Racial
{
    public class Dwarf
    {
        private Attributes StartingAttributes { get; }
        public int MovementRate { get; }
        public int StartingMaxKarma { get; }
        public List<RacialAbility> Racials { get; }

        public Dwarf()
        {
            StartingAttributes = new Attributes(
                new Dexterity(9),
                new Strength(10),
                new Toughness(12),
                new Perception(11),
                new Willpower(11),
                new Charisma(10));
            MovementRate = 10;
            StartingMaxKarma = 4;
        }
    }
}