using EarthdawnGamemasterAssistant.Annotations;
using EarthdawnGamemasterAssistant.Attributes;
using EarthdawnGamemasterAssistant.Disciplines;
using EarthdawnGamemasterAssistant.Racial;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Deployment.Application;
using System.Linq;
using System.Runtime.CompilerServices;

namespace EarthdawnGamemasterAssistant
{
    public class CharacterInfo : INotifyPropertyChanged
    {
        private Charisma _cha;

        private Dexterity _dex;

        private int _maxKarma;
        private Perception _per;

        private IRace _race;
        private Strength _str;

        private Toughness _tou;

        private Willpower _wil;

        public CharacterInfo()
        {
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public int ArmorPenalty => 0;

        public int AvailableAttributePoints { get; set; }

        public int AvailableLegend { get; set; }

        public int CarryingCapacity => CharacteristicTables.GetCarryingCapacityFromAttributeValue(Str.Value);

        public Charisma Cha
        {
            get => _cha;
            set
            {
                if (Equals(value, _cha)) return;
                _cha = value;
                OnPropertyChanged();
            }
        }

        public int CombatMovementRate => MovementRate / 2;

        public int DeathRating => UnconsciousnessRating +
                                  CharacteristicTables.GetStepFromValue(Tou.Value) +
                                  GetHighestCircle();

        public string Description { get; set; }

        public Dexterity Dex
        {
            get => _dex;
            set
            {
                _dex = value ?? throw new ArgumentNullException(nameof(value));
                OnPropertyChanged();
            }
        }

        public List<Discipline> Disciplines { get; set; }

        public int DurabilityRank { get; set; }

        public string InitiativeDice => CharacteristicTables.GetStepDice(
            CharacteristicTables.GetStepFromValue(Dex.Value - ArmorPenalty));

        public int LiftingCapacity => CarryingCapacity * 2;

        public int MaxKarma
        {
            get => _maxKarma;
            set
            {
                _maxKarma = value;
                OnPropertyChanged();
            }
        }

        public int MovementRate => Race?.MovementRate ?? 0;

        public int MysticArmor => Convert.ToInt32(Math.Floor(Convert.ToDouble(Wil.Value) / 6));

        public int MysticDefense => Convert.ToInt32(
            Math.Round(Convert.ToDouble(Wil.Value) / 2, MidpointRounding.AwayFromZero));

        public string Name { get; set; }

        public Perception Per
        {
            get => _per;
            set
            {
                if (Equals(value, _per)) return;
                _per = value;
                OnPropertyChanged();
            }
        }

        public int PhysicalDefense => Convert.ToInt32(
            Math.Round(Convert.ToDouble(Dex.Value) / 2, MidpointRounding.AwayFromZero)) + GetHighestPhysicalDefenseBonus();

        private int GetHighestPhysicalDefenseBonus()
        {
            var possibleBonus = (from d in Disciplines
                                 from ability in d.AbilityRules
                                 where ability is PhysicalDefenseAbilityRule
                                 where d.Circle >= ability.CircleRequirement
                                 select ability).ToList();
            return possibleBonus.Count > 0 ? possibleBonus.Max(ability => ability?.BonusAmount ?? 0) : 0;
        }


        public IRace Race
        {
            get => _race;
            set
            {
                if (Equals(value, _race)) return;
                _race = value;
                OnPropertyChanged();
            }
        }

        public int RecoveryTests => Convert.ToInt32(
            Math.Round(Convert.ToDouble(Tou.Value) / 6, MidpointRounding.AwayFromZero));

        public int SocialDefense => Convert.ToInt32(
            Math.Round(Convert.ToDouble(Cha.Value) / 2, MidpointRounding.AwayFromZero));

        public Strength Str
        {
            get => _str;
            set
            {
                if (Equals(value, _str)) return;
                _str = value;
                OnPropertyChanged();
            }
        }

        public int TotalLegend { get; set; }

        public Toughness Tou
        {
            get => _tou;
            set
            {
                if (Equals(value, _tou)) return;
                _tou = value;
                OnPropertyChanged();
            }
        }

        public int UnconsciousnessRating => Tou.Value * 2 + GetHighestDurabilityRating() * DurabilityRank;

        public Willpower Wil
        {
            get => _wil;
            set
            {
                if (Equals(value, _wil)) return;
                _wil = value;
                OnPropertyChanged();
            }
        }

        public int WoundThreshold => Convert.ToInt32(
            Math.Round(Convert.ToDouble(Tou.Value) / 2 + 2, MidpointRounding.AwayFromZero));

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int GetHighestCircle()
        {
            if (Disciplines != null)
            {
                return Disciplines.Count > 0 ? Disciplines.Max(discipline => discipline.Circle) : 1;
            }
            return 0;
        }

        private int GetHighestDurabilityRating()
        {
            if (Disciplines != null)
            {
                return Disciplines.Count > 0 ? Disciplines.Max(discipline => discipline.DurabilityRating) : 0;
            }
            return 0;
        }
    }
}