﻿using EarthdawnGamemasterAssistant.CharacterGenerator.Properties;
using EarthdawnGamemasterAssistant.CharacterGenerator.Talents;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

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

        private void Talent_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            TalentRankChanged?.Invoke(sender, e);
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

        public event PropertyChangedEventHandler TalentRankChanged;

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

        public List<(Talent talent, string disciplineName)> AvailableTalents()
        {
            var toReturn = new List<(Talent talent, string disciplineName)>();
            Disciplines.ForEach(
                discipline =>
                {
                    if (discipline.EarthdawnCircle > 0)
                    {
                        toReturn.Add((discipline.FreeTalent, discipline.Name));
                        discipline.NoviceTalentOptions.ToList()
                            .ForEach(noviceTalent => toReturn.Add((noviceTalent, discipline.Name)));
                    }
                    if (discipline.EarthdawnCircle > 3)
                    {
                        discipline.JourneymanTalentOptions.ToList()
                            .ForEach(journeymanTalent => toReturn.Add((journeymanTalent, discipline.Name)));
                    }
                    discipline.TalentsAtCircle
                        .Where(talentCircle => talentCircle.Key == discipline.EarthdawnCircle)
                        .ToList()
                        .ForEach(
                            talentsAtCircle => talentsAtCircle.Value.ForEach(
                                talentAtCircle => toReturn.Add((talentAtCircle, discipline.Name))));
                });
            toReturn.ForEach(tuple => tuple.talent.PropertyChanged += Talent_PropertyChanged);
            return toReturn;
        }
    }
}