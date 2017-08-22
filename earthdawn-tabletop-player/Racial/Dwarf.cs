using System.Collections.Generic;

namespace earthdawn_tabletop_player.Racial
{
    public class Dwarf : Race
    {
        public int MovementRate { get; }
        public int MaxKarma { get; }
        public List<RacialAbility> Racials { get; }

        private Dwarf(Dexterity dex, Strength str, Toughness tou, Perception per, Willpower wil, Charisma chr, int maxKarma = 4) : base(dex, str, tou, per, wil, chr, maxKarma)
        {
            MovementRate = 10;
            MaxKarma = maxKarma;

            Racials.Add(new HeatSight());
            Racials.Add(new StrongBack());
        }

        public static Dwarf CreateWithDefaultAttributes()
        {
            return new Dwarf(new Dexterity(9), new Strength(10), new Toughness(12), new Perception(11), new Willpower(11), new Charisma(10));
        }

        public static Dwarf CreateWithAttributes(int dex, int str, int tou, int per, int wil, int chr)
        {
            return new Dwarf(new Dexterity(dex), new Strength(str), new Toughness(tou), new Perception(per), new Willpower(wil), new Charisma(chr));
        }
    }
}