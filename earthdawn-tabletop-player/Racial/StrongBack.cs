namespace earthdawn_tabletop_player.Racial
{
    public class StrongBack : RacialAbility
    {
        public string Name { get; }
        public string Description { get; }

        public StrongBack()
        {
            Name = "Strong Back";
            Description = "Dwarf charaters have a +2 bonus to their Strength for the purposes of determining carrying capacity. Note that this is alread accounted for on your character sheet.";
        }

        protected override void Apply()
        {
            throw new System.NotImplementedException();
        }
    }
}