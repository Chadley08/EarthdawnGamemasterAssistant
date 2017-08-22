namespace earthdawn_tabletop_player.Racial
{
    public class Race
    {
        public Dexterity Dex { get; }
        public Strength Str { get; }
        public Toughness Tou { get; }
        public Perception Per { get; }
        public Willpower Wil { get; }
        public Charisma Chr { get; }
        public int MaxKarma { get; }

        public Race(Dexterity dex, Strength str, Toughness tou, Perception per, Willpower wil, Charisma chr, int maxKarma)
        {
            Dex = dex;
            Str = str;
            Tou = tou;
            Per = per;
            Wil = wil;
            Chr = chr;
            MaxKarma = maxKarma;
        }
        
    }
}