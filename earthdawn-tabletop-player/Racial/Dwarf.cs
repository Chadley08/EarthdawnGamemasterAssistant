using System.Collections.Generic;

namespace earthdawn_tabletop_player.Racial
{
    public class Dwarf
    {
        public Character ToCreate { get; }

        public Dwarf(Character toCreate)
        {
            ToCreate = toCreate;
        }
    }
}