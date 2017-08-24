using earthdawn_tabletop_player.Attributes;
using earthdawn_tabletop_player.Racial;
using System;
using System.Collections.Generic;
using System.Linq;

namespace earthdawn_tabletop_player
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

        private Character(
            List<Discipline> disciplines,
            int maxKarma,
            List<RacialAbility> racialAbilities,
            int totalLegend,
            int availableLegend,
            int durabilityRank,
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
            Dex = dex;
            Str = str;
            Tou = tou;
            Per = per;
            Wil = wil;
            Chr = chr;
            AttributePoints = 25;
        }

        public static Dwarf CreateDwarf(
            List<Discipline> disciplines,
            int maxKarma,
            List<RacialAbility> racialAbilities,
            int totalLegend,
            int availableLegend,
            int durabilityRank,
            Dexterity dex,
            Strength str,
            Toughness tou,
            Perception per,
            Willpower wil,
            Charisma chr)
        {
            return new Dwarf(
                new Character(
                    disciplines,
                    maxKarma,
                    racialAbilities,
                    totalLegend,
                    availableLegend,
                    durabilityRank,
                    dex,
                    str,
                    tou,
                    per,
                    wil,
                    chr));
        }

        private int GetHighestCircle()
        {
            return Disciplines.Max(discipline => discipline._Circle.Value);
        }

        private int GetHighestDurabilityRating()
        {
            return Disciplines.Max(discipline => discipline.DurabilityRating);
        }
    }
}