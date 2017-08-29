using EarthdawnGamemasterAssistant.Attributes;
using EarthdawnGamemasterAssistant.Racial;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EarthdawnGamemasterAssistant
{
    public class Character
    {
        private List<Discipline> Disciplines { get; }

        public int AttributePoints { get; }

        public int CarryingCapacity => CharacteristicTables.GetCarryingCapacityFromAttributeValue(Str.Value);

        public int LiftingCapacity => CarryingCapacity * 2;

        public int PhysicalDefense => Convert.ToInt32(
            Math.Round(Convert.ToDouble(Dex.Value) / 2, MidpointRounding.AwayFromZero));

        public int SocialDefense => Convert.ToInt32(
            Math.Round(Convert.ToDouble(Chr.Value) / 2, MidpointRounding.AwayFromZero));

        public int MysticDefense => Convert.ToInt32(
            Math.Round(Convert.ToDouble(Wil.Value) / 2, MidpointRounding.AwayFromZero));

        public int DurabilityRank { get; }
        public string Name { get; }
        public string Description { get; }

        public int UnconsciousnessRating => Tou.Value * 2 + GetHighestDurabilityRating() * DurabilityRank;

        public int DeathRating => UnconsciousnessRating + CharacteristicTables.GetStepFromValue(Tou.Value) + GetHighestCircle();

        public int WoundThreshold => Convert.ToInt32(
            Math.Round(Convert.ToDouble(Tou.Value) / 2 + 2, MidpointRounding.AwayFromZero));

        public int RecoveryTests => Convert.ToInt32(
            Math.Round(Convert.ToDouble(Tou.Value) / 6, MidpointRounding.AwayFromZero));

        public int MysticArmor => Convert.ToInt32(Math.Floor(Convert.ToDouble(Wil.Value) / 6));

        public int TotalLegend { get; }
        public int AvailableLegend { get; }

        public int MaxKarma { get; }
        public int MovementRate => CharacteristicTables.GetMovementRateFromValue(Dex.Value);
        public int CombatMovementRate => MovementRate / 2;

        public Dexterity Dex { get; }
        public Strength Str { get; }
        public Toughness Tou { get; }
        public Perception Per { get; }
        public Willpower Wil { get; }
        public Charisma Chr { get; }

        public List<RacialAbility> RacialAbilities { get; }

        public Character(
            List<Discipline> disciplines,
            int maxKarma,
            List<RacialAbility> racialAbilities,
            int totalLegend,
            int availableLegend,
            int durabilityRank,
            string name,
            string description,
            Dexterity dex,
            Strength str,
            Toughness tou,
            Perception per,
            Willpower wil,
            Charisma chr)
        {
            Disciplines = disciplines;
            MaxKarma = maxKarma;
            RacialAbilities = racialAbilities;
            TotalLegend = totalLegend;
            AvailableLegend = availableLegend;
            DurabilityRank = durabilityRank;
            Name = name;
            Description = description;
            Dex = dex;
            Str = str;
            Tou = tou;
            Per = per;
            Wil = wil;
            Chr = chr;
            AttributePoints = 25;
        }

        private int GetHighestCircle()
        {
            return Disciplines.Count > 0 ? Disciplines.Max(discipline => discipline._Circle.Value) : 1;
        }

        private int GetHighestDurabilityRating()
        {
            return Disciplines.Count > 0 ? Disciplines.Max(discipline => discipline.DurabilityRating) : 0;
        }
    }
}