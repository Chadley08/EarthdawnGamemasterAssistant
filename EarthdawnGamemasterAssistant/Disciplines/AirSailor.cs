using EarthdawnGamemasterAssistant.AbilityRules;
using EarthdawnGamemasterAssistant.Actions;
using EarthdawnGamemasterAssistant.Annotations;
using EarthdawnGamemasterAssistant.Attributes;
using EarthdawnGamemasterAssistant.Talents;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EarthdawnGamemasterAssistant.Disciplines
{
    public class AirSailor : IDiscipline
    {
        private int _circle;

        public int EarthdawnCircle
        {
            get => _circle;
            set
            {
                if (Equals(value, _circle)) return;
                _circle = value;
                OnPropertyChanged();
            }
        }

        public AirSailor(int earthdawnCircle)
        {
            EarthdawnCircle = earthdawnCircle;
        }

        public int DurabilityRating => 5;
        public string Name => "Air Sailor";

        public string Description =>
            "Air Sailors are the swashbuckling brotherhood of the sky. Air Sailors never leave their fellows behind and embrace the idea of togetherness, working to protect and spread civilization, rather than preying upon it.";

        public IReadOnlyList<Talent> DisciplineTalents => new List<Talent>()
        {
            new Talent("Avoid Blow", "", new Dexterity(0), 0, new FreeAction(), 1, true),
            new Talent("Climbing", "", new Dexterity(0), 0, new StandardAction(), 0, true),
            new Talent("Melee Weapons", "", new Dexterity(0), 0, new StandardAction(), 0, true),
            new Talent("Thread Weaving (Air Weaving)", "", new Perception(0), 0, new StandardAction(), 0, false),
            new Talent("Wind Catcher", "", new Willpower(0), 0, new StandardAction(), 1, false),
        };
        public IReadOnlyList<Talent> NoviceTalentOptions => new List<Talent>()
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
        public IReadOnlyList<Talent> JourneymanTalentOptions => new List<Talent>()
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
        public Talent FreeTalent =>
            new Talent("Air Sailing", "", new Willpower(0), 0, new SustainedAction(), 0, true);

        public IReadOnlyList<InitiativeAbilityRule> InitiativeAbilityRules { get; }
        public IReadOnlyList<GeneralAbilityRule> GeneralAbilityRules => new List<GeneralAbilityRule>()
        {
            new GeneralAbilityRule(
                "Collaborate: Once per round as a Simple action, the adept may take 1 Strain to give an ally a +2 bonus to a test towards achieving a common goal. The player should describe how they are assisting their ally",
                0,
                5
            )
        };
        public IReadOnlyList<RecoveryTestAbilityRule> RecoveryTestAbilityRules => new List<RecoveryTestAbilityRule>()
        {
            new RecoveryTestAbilityRule("The adept gains an additional Recovery test", 0, 7)
        };
        public IReadOnlyList<SocialDefenseAbilityRule> SocialDefenseAbilityRules => new List<SocialDefenseAbilityRule>()
        {
            new SocialDefenseAbilityRule("The adept adds +1 to their Social Defense", 1, 4)
        };
        public IReadOnlyList<PhysicalDefenseAbilityRule> PhysicalDefenseAbilityRules => new
            List<PhysicalDefenseAbilityRule>()
            {
                new PhysicalDefenseAbilityRule("The adept adds +1 to their physical defense", 1, 2),
                new PhysicalDefenseAbilityRule("The adept adds +2 to their Physical Defense", 2, 6),
                new PhysicalDefenseAbilityRule("The adept adds +3 to their Physical Defense", 3, 8)
            };
        public IReadOnlyList<MysticDefenseAbilityRule> MysticDefenseAbilityRules { get; }
        public IReadOnlyList<KarmaAbilityRule> KarmaAbilityRules => new List<KarmaAbilityRule>()
        {
            new KarmaAbilityRule(
                "The adept may spend Karma once per round on any action taken while on board an airship",
                0,
                1),
            new KarmaAbilityRule(
                "The adept may spend a Karma Point on Initiative tests",
                0,
                3),
            new KarmaAbilityRule(
                "The adept may spend 1 Karma Point on Interaction tests",
                0,
                5)
        };

        public IReadOnlyList<string> ImportantAttributes => new List<string>()
        {
            "Charisma",
            "Dexterity",
            "Willpower"
        };

        public IReadOnlyDictionary<int, List<Talent>> TalentsAtCircle => new Dictionary<int, List<Talent>>()
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

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}