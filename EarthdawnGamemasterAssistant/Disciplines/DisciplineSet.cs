using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using EarthdawnGamemasterAssistant.CharacterGenerator.Properties;

namespace EarthdawnGamemasterAssistant.CharacterGenerator.Disciplines
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

        public int DurabilityRatingBonus()
        {
            return Disciplines.Max(discipline => discipline.DurabilityRating);
        }

        public int PhysicalDefenseBonus()
        {
            // Tuple is bonus amount, circle requirement, and discipline circle
            var tuples = (from discipline in Disciplines
                          where discipline.PhysicalDefenseAbilityRules != null
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

        public int MysticDefenseBonus()
        {
            // Tuple is bonus amount, circle requirement, and discipline circle
            var tuples = (from discipline in Disciplines
                          where discipline.MysticDefenseAbilityRules != null
                          from abilityRule in discipline.MysticDefenseAbilityRules
                          select (
                          BonusAmount: abilityRule.BonusAmount,
                          CircleRequirement: abilityRule.CircleRequirement,
                          DisciplineCircle: discipline.EarthdawnCircle)).ToList();

            var grouping = tuples.GroupBy(tuple => tuple.CircleRequirement);

            return grouping.Sum(
                @group => @group.Max(
                    tuple => tuple.DisciplineCircle >= tuple.CircleRequirement ? tuple.BonusAmount : 0));
        }

        public int SocialDefenseBonus()
        {
            // Tuple is bonus amount, circle requirement, and discipline circle
            var tuples = (from discipline in Disciplines
                          where discipline.SocialDefenseAbilityRules != null
                          from abilityRule in discipline.SocialDefenseAbilityRules
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

        public int RecoveryTestBonus()
        {
            // Tuple is bonus amount, circle requirement, and discipline circle
            var tuples = (from discipline in Disciplines
                          where discipline.RecoveryTestAbilityRules != null
                          from abilityRule in discipline.RecoveryTestAbilityRules
                          select (
                          BonusAmount: abilityRule.BonusAmount,
                          CircleRequirement: abilityRule.CircleRequirement,
                          DisciplineCircle: discipline.EarthdawnCircle)).ToList();

            var grouping = tuples.GroupBy(tuple => tuple.CircleRequirement);

            return grouping.Sum(
                @group => @group.Max(
                    tuple => tuple.DisciplineCircle >= tuple.CircleRequirement ? tuple.BonusAmount : 0));
        }

        public int InitiativeBonus()
        {
            // Tuple is bonus amount, circle requirement, and discipline circle
            var tuples = (from discipline in Disciplines
                          where discipline.InitiativeAbilityRules != null
                          from abilityRule in discipline.InitiativeAbilityRules
                          select (
                          BonusAmount: abilityRule.BonusAmount,
                          CircleRequirement: abilityRule.CircleRequirement,
                          DisciplineCircle: discipline.EarthdawnCircle)).ToList();

            var grouping = tuples.GroupBy(tuple => tuple.CircleRequirement);

            return grouping.Sum(
                @group => @group.Max(
                    tuple => tuple.DisciplineCircle >= tuple.CircleRequirement ? tuple.BonusAmount : 0));
        }

        public int KarmaBonus()
        {
            // Tuple is bonus amount, circle requirement, and discipline circle
            var tuples = (from discipline in Disciplines
                          where discipline.KarmaAbilityRules != null
                          from abilityRule in discipline.KarmaAbilityRules
                          select (
                          BonusAmount: abilityRule.BonusAmount,
                          CircleRequirement: abilityRule.CircleRequirement,
                          DisciplineCircle: discipline.EarthdawnCircle)).ToList();

            var grouping = tuples.GroupBy(tuple => tuple.CircleRequirement);

            return grouping.Sum(
                @group => @group.Max(
                    tuple => tuple.DisciplineCircle >= tuple.CircleRequirement ? tuple.BonusAmount : 0));
        }
    }
}