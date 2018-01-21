using EarthdawnGamemasterAssistant.CharacterGenerator.AbilityRules;
using EarthdawnGamemasterAssistant.CharacterGenerator.Actions;
using EarthdawnGamemasterAssistant.CharacterGenerator.Attributes;
using EarthdawnGamemasterAssistant.CharacterGenerator.Properties;
using EarthdawnGamemasterAssistant.CharacterGenerator.Talents;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using EarthdawnGamemasterAssistant.CharacterGenerator.Skills;

namespace EarthdawnGamemasterAssistant.CharacterGenerator.Disciplines
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

        public IReadOnlyList<Talent> NoviceTalentOptions => TalentTable.CreateTalentsByName(
            new List<string>
            {
                "Acrobatic Defense",
                "Distract",
                "First Impression",
                "Great Leap",
                "Haggle",
                "Maneuver",
                "Navigation",
                "Speak Language",
                "Taunt",
                "Throwing Weapons"
            });

        public IReadOnlyList<Talent> JourneymanTalentOptions => TalentTable.CreateTalentsByName(
            new List<string>
            {
                "Air Speaking",
                "Battle Below",
                "Conceal Object",
                "Engaging Banter",
                "Etiquette",
                "Graceful Exit",
                "Leadership",
                "Resist Taunt",
                "Second Weapon",
                "Surprise Strike"
            });

        public Talent FreeTalent =>
            new Talent("Air Sailing", "", new Willpower(0), 0, new RankPlusAttributeStepRule(), new SustainedAction(), 0, true, "");

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
                TalentTable.CreateTalentsByName(new List<string>
                {
                    "Avoid Blow",
                    "Climbing",
                    "Melee Weapons",
                    "Thread Weaving (Air Weaving)",
                    "Wind Catcher"
                })
            },
            {
                2,
                TalentTable.CreateTalentsByName(new List<string>
                {
                    "Awareness"
                })
            },
            {
                3,
                TalentTable.CreateTalentsByName(new List<string>
                {
                    "Empathic Sense"
                })
            },
            {
                4,
                TalentTable.CreateTalentsByName(new List<string>
                {
                    "Wound Balance"
                })
            },
            {
                5,
                TalentTable.CreateTalentsByName(new List<string>
                {
                    "Heartening Laugh"
                })
            },
            {
                6,
                TalentTable.CreateTalentsByName(new List<string>
                {
                    "Air Dance"
                })
            },
            {
                7,
                TalentTable.CreateTalentsByName(new List<string>
                {
                    "Inspire Others"
                })
            },
            {
                8,
                TalentTable.CreateTalentsByName(new List<string>
                {
                    "Lion Heart"
                })
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