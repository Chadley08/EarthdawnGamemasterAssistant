using EarthdawnGamemasterAssistant.Annotations;
using EarthdawnGamemasterAssistant.Attributes;
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

        public List<Discipline> Disciplines { get; set; }

        private int _attributePoints;
        public int AttributePoints
        {
            get => CalculateAttributePoints();
            set => _attributePoints = value;
        }

        private int CalculateAttributePoints()
        {
            throw new NotImplementedException();
            
        }

        public int DurabilityRank { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TotalLegend { get; set; }
        public int AvailableLegend { get; set; }
        public int MaxKarma { get; set; }

        private Dexterity _dex;
        private Strength _str;
        private Toughness _tou;
        private Perception _per;
        private Willpower _wil;
        private Charisma _cha;
        private IRace _race;

        public Dexterity Dex
        {
            get => _dex;
            set
            {
                _dex = value ?? throw new ArgumentNullException(nameof(value));
                OnPropertyChanged();
                OnPropertyChanged(nameof(PhysicalDefense));
                OnPropertyChanged(nameof(MovementRate));
                OnPropertyChanged(nameof(InitiativeDice));
            }
        }

        public Strength Str
        {
            get => _str;
            set
            {
                if (Equals(value, _str)) return;
                _str = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(CarryingCapacity));
            }
        }

        public Toughness Tou
        {
            get => _tou;
            set
            {
                if (Equals(value, _tou)) return;
                _tou = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(UnconsciousnessRating));
                OnPropertyChanged(nameof(DeathRating));
                OnPropertyChanged(nameof(WoundThreshold));
                OnPropertyChanged(nameof(RecoveryTests));
            }
        }

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

        public Willpower Wil
        {
            get => _wil;
            set
            {
                if (Equals(value, _wil)) return;
                _wil = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(MysticDefense));
                OnPropertyChanged(nameof(MysticArmor));
            }
        }

        public Charisma Cha
        {
            get => _cha;
            set
            {
                if (Equals(value, _cha)) return;
                _cha = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(SocialDefense));
            }
        }

        public CharacterInfo(
            IRace race,
            List<Discipline> disciplines,
            int maxKarma,
            int totalLegend,
            int availableLegend,
            string name,
            string description,
            int attributePoints,
            Dexterity dex,
            Strength str,
            Toughness tou,
            Perception per,
            Willpower wil,
            Charisma cha)
        {
            Race = race;
            Disciplines = disciplines;
            MaxKarma = maxKarma;
            TotalLegend = totalLegend;
            AvailableLegend = availableLegend;
            Name = name;
            Description = description;
            Dex = dex;
            Str = str;
            Tou = tou;
            Per = per;
            Wil = wil;
            Cha = cha;
            AttributePoints = attributePoints;
        }

        public CharacterInfo()
        {
            
        }

        private int GetHighestCircle()
        {
            if (Disciplines != null)
            {
                return Disciplines.Count > 0 ? Disciplines.Max(discipline => discipline._Circle.Value) : 1;
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

        public int CarryingCapacity => CharacteristicTables.GetCarryingCapacityFromAttributeValue(Str.Value);

        public int LiftingCapacity => CarryingCapacity * 2;

        public int PhysicalDefense => Convert.ToInt32(
            Math.Round(Convert.ToDouble(Dex.Value) / 2, MidpointRounding.AwayFromZero));

        public int SocialDefense => Convert.ToInt32(
            Math.Round(Convert.ToDouble(Cha.Value) / 2, MidpointRounding.AwayFromZero));

        public int MysticDefense => Convert.ToInt32(
            Math.Round(Convert.ToDouble(Wil.Value) / 2, MidpointRounding.AwayFromZero));

        public int UnconsciousnessRating => Tou.Value * 2 + GetHighestDurabilityRating() * DurabilityRank;

        public int DeathRating => UnconsciousnessRating +
                                  CharacteristicTables.GetStepFromValue(Tou.Value) +
                                  GetHighestCircle();

        public int WoundThreshold => Convert.ToInt32(
            Math.Round(Convert.ToDouble(Tou.Value) / 2 + 2, MidpointRounding.AwayFromZero));

        public int RecoveryTests => Convert.ToInt32(
            Math.Round(Convert.ToDouble(Tou.Value) / 6, MidpointRounding.AwayFromZero));

        public int MysticArmor => Convert.ToInt32(Math.Floor(Convert.ToDouble(Wil.Value) / 6));
        public int MovementRate => CharacteristicTables.GetMovementRateFromValue(Dex.Value);
        public int CombatMovementRate => MovementRate / 2;
        public int ArmorPenalty => 0;

        public string InitiativeDice => CharacteristicTables.GetStepDice(
            CharacteristicTables.GetStepFromValue(Dex.Value - ArmorPenalty));

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}