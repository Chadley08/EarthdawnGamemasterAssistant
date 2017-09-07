namespace earthdawn_tabletop_player.Talents
{
    public class Talent
    {
        public string Name { get; }
        public string Description { get; }
        public ActionType Action { get; }
        public int Strain { get; }
        public bool SkillUse { get; }

        public Talent(string name, string description, ActionType action, int strain, bool skillUse)
        {
            Name = name;
            Description = description;
            Action = action;
            Strain = strain;
            SkillUse = skillUse;
        }
    }
}