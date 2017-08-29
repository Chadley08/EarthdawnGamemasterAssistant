using EarthdawnGamemasterAssistant.Attributes;
using System.Collections.Generic;

namespace EarthdawnGamemasterAssistant.Racial
{
    public class Dwarf : IRace
    {
        private Character ToCreate;

        public Dwarf()
        {
            
        }

        public Dwarf(Character toCreate)
        {
            ToCreate = toCreate;
        }

        public Character CreateDefault()
        {
            var racials = new List<RacialAbility>()
            {
                new HeatSight(),
                new StrongBack()
            };
            ToCreate = new Character(
                new List<Discipline>(),
                4,
                racials,
                0,
                0,
                0,
                "",
                "",
                new Dexterity(9),
                new Strength(10),
                new Toughness(12),
                new Perception(11),
                new Willpower(11),
                new Charisma(10));
            return ToCreate;
        }
    }
}