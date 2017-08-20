using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace earthdawn_tabletop_player.Dice
{
    public class Die
    {
        public int Sides { get; }
        public Die(int sides)
        {
            if (sides == 0)
            {
                throw new ArgumentException("Die cannot have zero sides.");
            }
            Sides = sides;
        }

        public int Roll()
        {
            var toCheck = StaticRandom.Instance.Next(Sides) + 1;
            var total = toCheck;

            // The steps associated with these "sides" of "dice" cannot explode.
            if (Sides != 2 && Sides != 3)
            {
                if (toCheck == Sides)
                {
                    total = RollAgain(total);
                }
            }
            Debug.WriteLine(total);
            return total;
        }

        public int RollAgain(int total)
        {
            var toCheck = StaticRandom.Instance.Next(Sides) + 1;
            if (toCheck == Sides)
            {
                total += RollAgain(total);
            }
            else
            {
                total += toCheck;
            }
            return total;
        }
    }
}