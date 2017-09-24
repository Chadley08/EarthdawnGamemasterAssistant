using EarthdawnGamemasterAssistant.Attributes;
using EarthdawnGamemasterAssistant.Disciplines;
using EarthdawnGamemasterAssistant.Racial;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            CharacteristicTables.GetStepFromValue(Dex.Value - ArmorPenalty) + GetHighestInitiativeBonus());

        public int LiftingCapacity => CarryingCapacity * 2;

        public int MaxKarma
        {
            get => _maxKarma + GetHighestKarmaBonus();
            set
            {
                _maxKarma = value;
                OnPropertyChanged();
            }
        }

        public int MovementRate => Race?.MovementRate ?? 0;

        public int MysticArmor => Convert.ToInt32(Math.Floor(Convert.ToDouble(Wil.Value) / 6));

        public int MysticDefense => Convert.ToInt32(
            Math.Round(Convert.ToDouble(Wil.Value) / 2, MidpointRounding.AwayFromZero)) + GetHighestMysticDefenseBonus();

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
            Math.Round(Convert.ToDouble(Dex.Value) / 2, MidpointRounding.AwayFromZero)) + GetHighestPerCirclePhysicalDefenseBonus();

        private int GetHighestPerCirclePhysicalDefenseBonus()
        {
            var totalBonus = 0;
            
            // Get the highest circle from the user selected disciplines
            var highestCircleValue = 0;
            Disciplines.ForEach(
                discipline =>
                {
                    var maxCircleValue = discipline.Circles.Count;
                    if (maxCircleValue >= highestCircleValue)
                    {
                        highestCircleValue = maxCircleValue;
                    }
                });

            
            for (var i = 0; i < highestCircleValue; i++)
            {
                var maxPerCircleDefenseBonus = 0;
                foreach (var discipline in Disciplines)
                {
                    if (discipline.Circles.Count > 0)
                    {
                        if (discipline.Circles.Count > i)
                        {
                            var defenseAbility = discipline.Circles[i]
                                .CircleSpecificAbilities.Where(ability => ability is PhysicalDefenseAbilityRule)
                                .ToList();
                            if (defenseAbility.Count == 1)
                            {
                                var defenseBonus =
                                    defenseAbility[0].BonusAmount;
                                if (defenseBonus >= maxPerCircleDefenseBonus)
                                {
                                    maxPerCircleDefenseBonus = defenseBonus;
                                }
                            }
                        }
                    }
                }
                totalBonus += maxPerCircleDefenseBonus;
            }
            return totalBonus;
        }

        private int GetHighestMysticDefenseBonus()
        {
            return 0;
        }

        private int GetHighestInitiativeBonus()
        {
            return 0;
        }

        private int GetHighestKarmaBonus()
        {
            return 0;
        }

        private int GetHighestSocialDefenseBonus()
        {
            return 0;
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
            Math.Round(Convert.ToDouble(Tou.Value) / 6, MidpointRounding.AwayFromZero)) + GetHighestRecoveryTestBonus();

        private int GetHighestRecoveryTestBonus()
        {
            return 0;
        }

        public int SocialDefense => Convert.ToInt32(
            Math.Round(Convert.ToDouble(Cha.Value) / 2, MidpointRounding.AwayFromZero)) + GetHighestSocialDefenseBonus();

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

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int GetHighestCircle()
        {
            if (Disciplines != null)
            {
                return Disciplines.Count > 0 ? Disciplines.Max(discipline => discipline.Circles.Count) : 1;
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