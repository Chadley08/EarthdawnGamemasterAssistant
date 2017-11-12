using EarthdawnGamemasterAssistant.CharacterGenerator.Attributes;
using System.Collections.Generic;

namespace EarthdawnGamemasterAssistant.CharacterGenerator.Racial
{
    public class Dwarf : IRace
    {
        public Dexterity BaseDex => new Dexterity(9);
        public Strength BaseStr => new Strength(10);
        public Toughness BaseTou => new Toughness(12);
        public Perception BasePer => new Perception(11);
        public Willpower BaseWil => new Willpower(11);
        public Charisma BaseCha => new Charisma(10);
        public int MovementRate => 10;
        public int CarryingCapacityModifer => 2;
        public int KarmaModifier => 4;

        public CharacterInfo _CharacterInfo { get; }

        private static IReadOnlyList<RacialAbility> RacialAbilities => new List<RacialAbility>()
        {
            new HeatSight(),
            new StrongBack()
        };

        public Dwarf(CharacterInfo characterInfo)
        {
            _CharacterInfo = characterInfo;
        }

        public IReadOnlyList<RacialAbility> GetRacialAbilities()
        {
            return RacialAbilities;
        }

        public int GetCarryingCapacity() => CharacteristicTables.GetCarryingCapacityFromAttributeValue(_CharacterInfo.Str.Value + 2);
    }
}