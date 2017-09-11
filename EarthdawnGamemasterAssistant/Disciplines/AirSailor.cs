using EarthdawnGamemasterAssistant.Attributes;
using EarthdawnGamemasterAssistant.Talents;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace EarthdawnGamemasterAssistant.Disciplines
{
    public class AirSailor : Discipline
    {
        protected AirSailor(Circle circle) : base(5, circle, Abilities.ToList())
        {
        }

        public static string Description =>
            "Air Sailors are the swashbuckling brotherhood of the sky. Air Sailors never leave their fellows behind and embrace the idea of togetherness, working to protect and spread civilization, rather than preying upon it.";

        public static IReadOnlyList<Talent> DisciplineTalents = new List<Talent>()
        {
        };

        public static IReadOnlyList<Talent> NoviceTalentOptions = new List<Talent>()
        {
            new Talent("Acrobatic Defense", "", new Dexterity(0), 0, new SimpleAction(), 1, true),
            new Talent("Distract", "", new Charisma(0), 0, new SimpleAction(), 1, true),
            new Talent("First Impression", "", new Charisma(0), 0, new StandardAction(), 0, true),
            new Talent("Great Leap", "", new Dexterity(0), 0, new FreeAction(), 1, true),
            new Talent("Haggle", "", new Charisma(0), 0, new SustainedAction(), 0, true),
            new Talent("Maneuver", "", new Dexterity(0), 0, new SimpleAction(), 1, true),
            new Talent("Navigation", "", new Perception(0), 0, new SustainedAction(), 0, true),
            new Talent("Speak Language", "", new Perception(0), 0, new StandardAction(), 1, false),
            new Talent("Taunt", "", new Charisma(0), 0, new SimpleAction(), 1, true),
            new Talent("Throwing Weapons", "", new Dexterity(0), 0, new StandardAction(), 0, true)
        };

        public static IReadOnlyList<Talent> JourneymanTalentOptions = new List<Talent>()
        {
            new Talent("Air Speaking", "", new Perception(0), 0, new SimpleAction(), 1, false),
            new Talent("Battle Bellow", "", new Charisma(0), 0, new SimpleAction(), 1, true),
            new Talent("Conceal Object", "", new Dexterity(0), 0, new StandardAction(), 1, true),
            new Talent("Engaging Banter", "", new Charisma(0), 0, new StandardAction(), 0, true),
            new Talent("Etiquette", "", new Charisma(0), 0, new SustainedAction(), 0, true),
            new Talent("Graceful Exit", "", new Charisma(0), 0, new StandardAction(), 0, true),
            new Talent("Leadership", "", new Charisma(0), 0, new SustainedAction(), 0, true),
            new Talent("Resist Taunt", "", new Willpower(0), 0, new FreeAction(), 1, true),
            new Talent("Second Weapon", "", new Dexterity(0), 0, new SimpleAction(), 1, true),
            new Talent("Surprise Strike", "", new Strength(0), 0, new FreeAction(), 1, true)
        };

        public static readonly Talent FreeTalent =
            new Talent("Air Sailing", "", new Willpower(0), 0, new SustainedAction(), 0, true);

        public static IReadOnlyList<AbilityRule> Abilities = new List<AbilityRule>()
        {
        };

        public static IReadOnlyList<string> ImportantAttributes = new List<string>()
        {
            "Charisma",
            "Dexterity",
            "Willpower"
        };

        public static IReadOnlyDictionary<int, List<Talent>> TalentsAtCircle = new Dictionary<int, List<Talent>>()
        {
            {
                1,
                new List<Talent>()
                {
                    new Talent("Avoid Blow", "", new Dexterity(0), 0, new FreeAction(), 1, true),
                    new Talent("Climbing", "", new Dexterity(0), 0, new StandardAction(), 0, true),
                    new Talent("Melee Weapons", "", new Dexterity(0), 0, new StandardAction(), 0, true),
                    new Talent(
                        "Thread Weaving (Air Weaving)",
                        "",
                        new Perception(0),
                        0,
                        new StandardAction(),
                        0,
                        false),
                    new Talent("Wind Catcher", "", new Willpower(0), 0, new StandardAction(), 1, false)
                }
            },
            {
                2,
                new List<Talent>()
                {
                    new Talent("Awareness", "", new Perception(0), 0, new SimpleAction(), 0, true)
                }
            },
            {
                3,
                new List<Talent>()
                {
                    new Talent("Empathic Sense", "", new Charisma(0), 0, new FreeAction(), 1, true)
                }
            },
            {
                4,
                new List<Talent>()
                {
                    new Talent("Wound Balance", "", new Strength(0), 0, new FreeAction(), 0, true)
                }
            },
            {
                5,
                new List<Talent>()
                {
                    new Talent("Hearteniing Laugh", "", new Charisma(0), 0, new SimpleAction(), 1, true)
                }
            },
            {
                6,
                new List<Talent>()
                {
                    new Talent("Air Dance", "", new Dexterity(0), 0, new FreeAction(), 2, false)
                }
            },
            {
                7,
                new List<Talent>()
                {
                    new Talent("Inspire Others", "", new Charisma(0), 0, new StandardAction(), 0, false)
                }
            },
            {
                8,
                new List<Talent>()
                {
                    new Talent("Lion Heart", "", new Willpower(0), 0, new FreeAction(), 1, false)
                }
            }
        };
    }
}