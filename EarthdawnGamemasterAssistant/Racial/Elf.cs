using EarthdawnGamemasterAssistant.CharacterGenerator.Attributes;
using System.Collections.Generic;

namespace EarthdawnGamemasterAssistant.CharacterGenerator.Racial
{
    public class Elf : IRace
    {
        public int GetCarryingCapacity() => CharacteristicTables.GetCarryingCapacityFromAttributeValue(_CharacterInfo.Str.Value);

        public Dexterity BaseDex => new Dexterity(12);
        public Strength BaseStr => new Strength(10);
        public Toughness BaseTou => new Toughness(8);
        public Perception BasePer => new Perception(11);
        public Willpower BaseWil => new Willpower(11);
        public Charisma BaseCha => new Charisma(11);
        public int MovementRate => 14;
        public int KarmaModifier => 4;

        public CharacterInfo _CharacterInfo { get; }

        private static IReadOnlyList<RacialAbility> RacialAbilities => new List<RacialAbility>()
        {
            new LowLightVision()
        };

        public Elf(CharacterInfo characterInfo)
        {
            _CharacterInfo = characterInfo;
        }

        public IReadOnlyList<RacialAbility> GetRacialAbilities()
        {
            return RacialAbilities;
        }
    }
}