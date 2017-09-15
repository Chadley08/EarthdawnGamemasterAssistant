using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using EarthdawnGamemasterAssistant.Annotations;

namespace EarthdawnGamemasterAssistant.Disciplines
{
    public abstract class Discipline : INotifyPropertyChanged
    {
        public int DurabilityRating { get; }
        public List<AbilityRule> AbilityRules { get; }

        private int _circle;

        public int Circle
        {
            get => _circle;
            set
            {
                if (Equals(value, _circle)) return;
                _circle = value;
                OnPropertyChanged();
            }
        }

        public abstract string Name { get; }

        protected Discipline(int durabilityRating, int circle, List<AbilityRule> abilityRules)
        {
            DurabilityRating = durabilityRating;
            Circle = circle;
            AbilityRules = abilityRules;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}