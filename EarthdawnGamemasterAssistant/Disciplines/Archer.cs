using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using EarthdawnGamemasterAssistant.Annotations;

namespace EarthdawnGamemasterAssistant.Disciplines
{
    internal class Archer : IDiscipline
    {
        public Archer(int earthdawnCircle)
        {
            EarthdawnCircle = earthdawnCircle;
        }

        public IReadOnlyList<PhysicalDefenseAbilityRule> PhysicalDefenseAbilityRules => new List<PhysicalDefenseAbilityRule>
        {
            new PhysicalDefenseAbilityRule("Character gains +1 to physical defense", 500, 2),
            new PhysicalDefenseAbilityRule("Character gains +1 to physical defense", 1, 3)
        };

        public  int DurabilityRating => 5;
        public  string Name => "Archer";
        private int _circle;
        public int EarthdawnCircle {
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