namespace earthdawn_tabletop_player
{
    public class Attributes
    {
        public Dexterity Dex { get; }
        public Strength Str { get; }
        public Toughness Tou { get; }
        public Perception Per { get; }
        public Willpower Will { get; }
        public Charisma Cha { get; }

        public Attributes(Dexterity dex, Strength str, Toughness tou, Perception per, Willpower will, Charisma cha )
        {
            Dex = dex;
            Str = str;
            Tou = tou;
            Per = per;
            Will = will;
            Cha = cha;
        }

        public Attributes Copy()
        {
            Attributes toReturn = new Attributes(this.Dex, this.Str, this.Tou, this.Per, this.Will, this.Cha);
            return toReturn;
        }
    }
}