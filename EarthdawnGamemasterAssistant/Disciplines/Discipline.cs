using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace EarthdawnGamemasterAssistant.Disciplines
{
    public abstract class Discipline : INotifyPropertyChanged
    {
        public int DurabilityRating { get; }
        public List<AbilityRule> AllAbilityRules { get; }

        private List<Circle> _Circles;

        public List<Circle> Circles
        {
            get => _Circles;
            set
            {
                if (Equals(value, _Circles)) return;
                _Circles = value;
                OnPropertyChanged();
            }
        }

        public abstract string Name { get; }

        protected Discipline(int durabilityRating, int circleValue, List<AbilityRule> allAbilityRules)
        {
            DurabilityRating = durabilityRating;
            AllAbilityRules = allAbilityRules;
            var circles = new List<Circle>();
            for (var i = 1; i <= circleValue; i++)
            {
                circles.Add(new Circle(i, allAbilityRules.Where(ability => ability.CircleRequirement == i).ToList()));
            }
            Circles = circles;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}