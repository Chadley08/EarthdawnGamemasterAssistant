using EarthdawnGamemasterAssistant.Annotations;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using EarthdawnGamemasterAssistant.AbilityRules;

namespace EarthdawnGamemasterAssistant.Disciplines
{
    internal class Archer : IDiscipline
    {
        public Archer(int earthdawnCircle)
        {
            EarthdawnCircle = earthdawnCircle;
        }

        public IReadOnlyList<PhysicalDefenseAbilityRule> PhysicalDefenseAbilityRules => new
            List<PhysicalDefenseAbilityRule>
            {
                new PhysicalDefenseAbilityRule("Character gains +1 to physical defense", 500, 2),
                new PhysicalDefenseAbilityRule("Character gains +1 to physical defense", 1, 3)
            };

        public IReadOnlyList<MysticDefenseAbilityRule> MysticDefenseAbilityRules { get; }
        public IReadOnlyList<KarmaAbilityRule> KarmaAbilityRules { get; }
        public IReadOnlyList<InitiativeAbilityRule> InitiativeAbilityRules { get; }
        public IReadOnlyList<GeneralAbilityRule> GeneralAbilityRules { get; }
        public IReadOnlyList<RecoveryTestAbilityRule> RecoveryTestAbilityRules { get; }
        public IReadOnlyList<SocialDefenseAbilityRule> SocialDefenseAbilityRules { get; }

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