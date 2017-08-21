using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace earthdawn_tabletop_player
{
    public class Character
    {
        private Discipline MyDiscipline { get; }
        private Racial.Race MyRace { get; }
        private Attributes MyAttributes { get; }
        public Character(Discipline myDiscipline, Racial.Race myRace, Attributes myAttributes)
        {
            MyDiscipline = myDiscipline;
            MyRace = myRace;
            MyAttributes = myAttributes;
        }
    }
}
