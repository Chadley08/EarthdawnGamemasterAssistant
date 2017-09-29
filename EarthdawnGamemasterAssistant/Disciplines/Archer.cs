using EarthdawnGamemasterAssistant.Annotations;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using EarthdawnGamemasterAssistant.AbilityRules;
using EarthdawnGamemasterAssistant.Actions;
using EarthdawnGamemasterAssistant.Attributes;
using EarthdawnGamemasterAssistant.Talents;

namespace EarthdawnGamemasterAssistant.Disciplines
{
    internal class Archer : IDiscipline
    {
        public Archer(int earthdawnCircle)
        {
            EarthdawnCircle = earthdawnCircle;
        }

        public string Description =>
            "The Archer learns the art of the bow and crossbow and by extension, all types of ranged attacks. This Discipline stresses accuracy and speed. Most Archers show greatly enhanced perceptive powers, frequently noticing things that others miss.";

        public IReadOnlyList<string> ImportantAttributes => new List<string>
        {
            "Dexterity",
            "Perception"
        };

        public IReadOnlyList<PhysicalDefenseAbilityRule> PhysicalDefenseAbilityRules => new
            List<PhysicalDefenseAbilityRule>
            {
                new PhysicalDefenseAbilityRule("Character gains +1 to physical defense", 1, 2),
                new PhysicalDefenseAbilityRule("Character gains +2 to physical defense", 2, 6),
                new PhysicalDefenseAbilityRule("Character gains +3 to physical defense", 3, 8)
            };
        public IReadOnlyList<MysticDefenseAbilityRule> MysticDefenseAbilityRules => new List<MysticDefenseAbilityRule>()
        {
            new MysticDefenseAbilityRule("The adept adds +1 to his Mystic Defense", 1, 4)
        };
        public IReadOnlyList<KarmaAbilityRule> KarmaAbilityRules => new List<KarmaAbilityRule>()
        {
            new KarmaAbilityRule("The adept may spend a Karma Point on Perception tests that rely on sight.", 0, 1),
            new KarmaAbilityRule("The adept may spend a Karma Point on Initiative tests.", 0, 3),
            new KarmaAbilityRule("The adept may spend a Karma Point on Damage tests made with ranged weapons.", 0, 5)
        };
        public IReadOnlyList<InitiativeAbilityRule> InitiativeAbilityRules => new List<InitiativeAbilityRule>()
        {
            new InitiativeAbilityRule("The adept gains +1 Step to their Initiative", 1, 7)
        };
        public IReadOnlyList<GeneralAbilityRule> GeneralAbilityRules => new List<GeneralAbilityRule>()
        {
            new GeneralAbilityRule("Create Projectile: Once per round as a Standard action, the adept may take 1 Strain and make an Arrow Weaving (6) test. Each success creates one arrow, bolt, or throwing weapon. All items created must be of the same type. The projectiles last for Arrow Weaving Rank in minutes, after which they disappear. They are treated as normal weapons or ammunition for the purpose of talents or spells that require it.", 0, 5)
        };
        public IReadOnlyList<RecoveryTestAbilityRule> RecoveryTestAbilityRules => new List<RecoveryTestAbilityRule>();
        public IReadOnlyList<SocialDefenseAbilityRule> SocialDefenseAbilityRules => new List<SocialDefenseAbilityRule>();

        public IReadOnlyList<Talent> DisciplineTalents => new List<Talent>()
        {
            new Talent("Avoid Blow", "", new Dexterity(0), 0, new FreeAction(), 1, true),
            new Talent("Missile Weapons", "", new Dexterity(0), 0, new StandardAction(), 0, true),
            new Talent("Mystic Aim", "", new Perception(0), 0, new SimpleAction(), 1, false),
            new Talent("Thread Weaving (Arrow Weaving)", "", new Perception(0), 0, new StandardAction(), 0, false),
            new Talent("True Shot", "", new NullAttribute(), 0, new FreeAction(), 2, false)
        };
        public IReadOnlyList<Talent> NoviceTalentOptions => new List<Talent>()
        {
            new Talent("Awareness", "", new Perception(0), 0, new SimpleAction(), 0, true),
            new Talent("Climbing", "", new Dexterity(0), 0, new StandardAction(), 0, true),
            new Talent("Creature Analysis", "", new Perception(0), 0, new SimpleAction(), 1, false),
            new Talent("First Impression", "", new Charisma(0), 0, new StandardAction(), 0, true),
            new Talent("Impressive Display", "", new NullAttribute(), 0, new SimpleAction(), 1, true),
            new Talent("Navigation", "", new Perception(0), 0, new SustainedAction(), 0, true),
            new Talent("Stealthy Stride", "", new Dexterity(0), 0, new SimpleAction(), 0, true),
            new Talent("Throwing Weapons", "", new Perception(0), 0, new StandardAction(), 0, true),
            new Talent("Tracking", "", new Perception(0), 0, new StandardAction(), 0, true),
            new Talent("Wilderness Survival", "", new Perception(0), 0, new SustainedAction(), 0, true),
        };
        public IReadOnlyList<Talent> JourneymanTalentOptions => new List<Talent>()
        {
            new Talent("Conversation", "", new Charisma(0), 0, new SustainedAction(), 0, true),
            new Talent("Danger Sense", "", new Dexterity(0), 0, new FreeAction(), 1, true),
            new Talent("Distract", "", new Charisma(0), 0, new SimpleAction(), 1, true),
            new Talent("Etiquette", "", new Charisma(0), 0, new SustainedAction(), 0, true),
            new Talent("Evidence Analysis", "", new Perception(0), 0, new SustainedAction(), 1, true),
            new Talent("Resist Taunt", "", new Willpower(0), 0, new FreeAction(), 1, true),
            new Talent("Speak Language", "", new Perception(0), 0, new StandardAction(), 1, false),
            new Talent("Steel Thought", "", new Willpower(0), 0, new FreeAction(), 1, false),
            new Talent("Stopping Aim", "", new Charisma(0), 0, new StandardAction(), 1, false),
            new Talent("Tiger Spring", "", new NullAttribute(), 0, new FreeAction(), 1, false),
        };
        public Talent FreeTalent => new NullTalent();
        public IReadOnlyDictionary<int, List<Talent>> TalentsAtCircle => new Dictionary<int, List<Talent>>()
        {
            {
                1,
                new List<Talent>()
                {
                    new Talent("Avoid Blow", "", new Dexterity(0), 0, new FreeAction(), 1, true),
                    new Talent("Missile Weapons", "", new Dexterity(0), 0, new StandardAction(), 0, true),
                    new Talent("Mystic Aim", "", new Perception(0), 0, new SimpleAction(), 1, false),
                    new Talent("Thread Weaving (Arrow Weaving)", "", new Perception(0), 0, new StandardAction(), 0, false),
                    new Talent("True Shot", "", new NullAttribute(), 0, new FreeAction(), 2, false)
                }
            },
            {
                2,
                new List<Talent>()
                {
                    new Talent("Mystic Pursuit", "", new Perception(0), 0, new StandardAction(), 2, false)
                }
            },
            {
                3,
                new List<Talent>()
                {
                    new Talent("Anticipate Blow", "", new Perception(0), 0, new SimpleAction(), 1, true)
                }
            },
            {
                4,
                new List<Talent>()
                {
                    new Talent("Long Shot", "", new NullAttribute(), 0, new SimpleAction(), 1, false)
                }
            },
            {
                5,
                new List<Talent>()
                {
                    new Talent("Spot Armor Flaw", "", new Perception(0), 0, new SimpleAction(), 1, false)
                }
            },
            {
                6,
                new List<Talent>()
                {
                    new Talent("Bank Shot", "", new Dexterity(0), 0, new SimpleAction(), 1, false)
                }
            },
            {
                7,
                new List<Talent>()
                {
                    new Talent("Flame Arrow", "", new Willpower(0), 0, new FreeAction(), 1, false)
                }
            },
            {
                8,
                new List<Talent>()
                {
                    new Talent("Second Shot", "", new Dexterity(0), 0, new SimpleAction(), 2, true)
                }
            }
        };

        public int DurabilityRating => 5;
        public string Name => "Archer";
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

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}