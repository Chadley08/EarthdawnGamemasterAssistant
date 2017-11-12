using EarthdawnGamemasterAssistant.CharacterGenerator.Attributes;
using EarthdawnGamemasterAssistant.CharacterGenerator.Disciplines;
using EarthdawnGamemasterAssistant.CharacterGenerator.Racial;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EarthdawnGamemasterAssistant.CharacterGenerator
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

        public CharacterInfo(DisciplineSet disciplines)
        {
            Disciplines = disciplines;
        }

        public EarthdawnAttribute GetMatchingAttribute(EarthdawnAttribute toMatch)
        {
            switch (toMatch.Name)
            {
                case "Str":
                    return Str;

                case "Dex":
                    return Dex;

                case "Per":
                    return Per;

                case "Cha":
                    return Cha;

                case "Tou":
                    return Tou;

                case "Wil":
                    return Wil;

                case "":
                    return new NullAttribute();

                default:
                    throw new InvalidOperationException("No matching attribute named" + toMatch.Name);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public int ArmorPenalty => 0;

        public int AvailableAttributePoints { get; set; }

        public int AvailableLegend { get; set; }

        public int CarryingCapacity => Race?.GetCarryingCapacity() ?? Str.Value;

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
                                  Disciplines.GetHighestCircle();

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

        public DisciplineSet Disciplines { get; set; }

        public int DurabilityRank { get; set; }

        public string InitiativeDice => CharacteristicTables.GetStepDice(
            CharacteristicTables.GetStepFromValue(Dex.Value - ArmorPenalty) + Disciplines.InitiativeBonus());

        public int LiftingCapacity => CarryingCapacity * 2;

        public int MaxKarma
        {
            get => _maxKarma + Disciplines.KarmaBonus();
            set
            {
                _maxKarma = value;
                OnPropertyChanged();
            }
        }

        public int MovementRate => Race?.MovementRate ?? 0;

        public int MysticArmor => Convert.ToInt32(Math.Floor(Convert.ToDouble(Wil.Value) / 6));

        public int MysticDefense => Convert.ToInt32(
                                        Math.Round(Convert.ToDouble(Wil.Value) / 2, MidpointRounding.AwayFromZero)) +
                                    Disciplines.MysticDefenseBonus();

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
                                          Math.Round(Convert.ToDouble(Dex.Value) / 2, MidpointRounding.AwayFromZero)) +
                                      Disciplines.PhysicalDefenseBonus();

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
                                        Math.Round(Convert.ToDouble(Tou.Value) / 6, MidpointRounding.AwayFromZero)) +
                                    Disciplines.RecoveryTestBonus();

        public int SocialDefense => Convert.ToInt32(
                                        Math.Round(Convert.ToDouble(Cha.Value) / 2, MidpointRounding.AwayFromZero)) +
                                    Disciplines.SocialDefenseBonus();

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

        public int UnconsciousnessRating => Tou.Value * 2 + Disciplines.DurabilityRatingBonus() * DurabilityRank;

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
    }
}