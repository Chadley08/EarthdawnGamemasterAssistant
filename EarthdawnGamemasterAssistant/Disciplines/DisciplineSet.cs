using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using EarthdawnGamemasterAssistant.Annotations;

namespace EarthdawnGamemasterAssistant.Disciplines
{
    public class DisciplineSet : INotifyPropertyChanged
    {
        private List<IDiscipline> Disciplines { get; }

        public DisciplineSet(List<IDiscipline> disciplines)
        {
            Disciplines = disciplines;
            Disciplines.ForEach(discipline => discipline.PropertyChanged += Discipline_PropertyChanged);
        }

        private void Discipline_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(sender, e);
        }

        public IDiscipline this[string key] => GetValue(key);

        private IDiscipline GetValue(string key)
        {
            return Disciplines.First(discipline => discipline.Name == key);
        }

        public int GetHighestCircle()
        {
            return Disciplines.Max(discipline => discipline.EarthdawnCircle);
        }

        public int GetHighestDurabilityRating()
        {
            return Disciplines.Max(discipline => discipline.DurabilityRating);
        }

        public int GetHighestPhysicalDefenseBonus()
        {
            var totalBonus = 0;
            var tuples = new List<Tuple<int, int, int>>();
            foreach (var discipline in Disciplines)
            {
                foreach (var abilityRule in discipline.PhysicalDefenseAbilityRules)
                {
                    tuples.Add(new Tuple<int, int, int>(abilityRule.BonusAmount, abilityRule.CircleRequirement, discipline.EarthdawnCircle));
                }
            }
            var grouping = tuples.GroupBy(tuple => tuple.Item2);
            foreach (var group in grouping)
            {
                totalBonus += group.Max(
                    tuple =>
                    {
                        if (tuple.Item3 >= tuple.Item2)
                        {
                            return tuple.Item1;
                        }
                        else
                        {
                            return 0;
                        }
                    });
            }

            return totalBonus;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}