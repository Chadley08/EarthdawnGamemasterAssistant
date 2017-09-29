using EarthdawnGamemasterAssistant.Annotations;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

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
            return Disciplines.FirstOrDefault(discipline => discipline.Name == key);
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
            // Tuple is bonus amount, circle requirement, and discipline circle
            var tuples = (from discipline in Disciplines
                          from abilityRule in discipline.PhysicalDefenseAbilityRules
                          select (
                          BonusAmount: abilityRule.BonusAmount,
                          CircleRequirement: abilityRule.CircleRequirement,
                          DisciplineCircle: discipline.EarthdawnCircle)).ToList();

            var grouping = tuples.GroupBy(tuple => tuple.CircleRequirement);

            return grouping.Sum(
                @group => @group.Max(
                    tuple => tuple.DisciplineCircle >= tuple.CircleRequirement ? tuple.BonusAmount : 0));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}