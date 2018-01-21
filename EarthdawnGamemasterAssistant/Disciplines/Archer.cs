using EarthdawnGamemasterAssistant.CharacterGenerator.AbilityRules;
using EarthdawnGamemasterAssistant.CharacterGenerator.Actions;
using EarthdawnGamemasterAssistant.CharacterGenerator.Attributes;
using EarthdawnGamemasterAssistant.CharacterGenerator.Properties;
using EarthdawnGamemasterAssistant.CharacterGenerator.Talents;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EarthdawnGamemasterAssistant.CharacterGenerator.Disciplines
{
    public class Archer : IDiscipline
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

        public IReadOnlyList<Talent> NoviceTalentOptions => TalentTable.CreateTalentsByName(
            new List<string>
            {
                "Awareness",
                "Climbing",
                "Creature Analysis",
                "First Impression",
                "Impressive Display",
                "Navigation",
                "Stealthy Stride",
                "Throwing Weapons",
                "Tracking",
                "Wilderness Survival"
            });

        public IReadOnlyList<Talent> JourneymanTalentOptions => TalentTable.CreateTalentsByName(
            new List<string>
            {
                "Conversation",
                "Danger Sense",
                "Distract",
                "Etiquette",
                "Evidence Analysis",
                "Resist Taunt",
                "Speak Language",
                "Steel Thought",
                "Stopping Aim",
                "Tiger Spring"
            });

        public Talent FreeTalent => new Talent("Call Missile", "", new Perception(0), 0, new RankPlusAttributeStepRule(), new SimpleAction(), 1, false, "");

        public IReadOnlyDictionary<int, List<Talent>> TalentsAtCircle => new Dictionary<int, List<Talent>>()
        {
            {
                1,
                TalentTable.CreateTalentsByName(new List<string>
                {
                    "Avoid Blow",
                    "Missile Weapons",
                    "Mystic Aim",
                    "Thread Weaving (Arrow Weaving)",
                    "True Shot"
                })
            },
            {
                2,
                TalentTable.CreateTalentsByName(new List<string>
                {
                    "Mystic Pursuit"
                })
            },
            {
                3,
                TalentTable.CreateTalentsByName(new List<string>
                {
                    "Anticipate Blow"
                })
            },
            {
                4,
                TalentTable.CreateTalentsByName(new List<string>
                {
                    "Long Shot"
                })
            },
            {
                5,
                TalentTable.CreateTalentsByName(new List<string>
                {
                    "Spot Armor Flaw"
                })
            },
            {
                6,
                TalentTable.CreateTalentsByName(new List<string>
                {
                    "Bank Shot"
                })
            },
            {
                7,
                TalentTable.CreateTalentsByName(new List<string>
                {
                    "Flame Arrow"
                })
            },
            {
                8,
                TalentTable.CreateTalentsByName(new List<string>
                {
                    "Second Shot"
                })
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