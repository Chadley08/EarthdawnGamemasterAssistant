using System.Collections.Generic;
using EarthdawnGamemasterAssistant.Attributes;

namespace EarthdawnGamemasterAssistant.Racial
{
    public class Dwarf
    {
        public Character ToCreate { get; }

        public Dwarf(Character toCreate)
        {
            ToCreate = toCreate;
        }

        public static Dwarf CreateUsingDefaults()
        {
            var racials = new List<RacialAbility>()
            {
                new HeatSight(),
                new StrongBack()
            };
            return Character.CreateDwarf(
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
        }
    }
}