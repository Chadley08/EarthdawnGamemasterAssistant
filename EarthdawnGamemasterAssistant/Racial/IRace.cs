using EarthdawnGamemasterAssistant.CharacterGenerator.Attributes;
using System.Collections.Generic;

namespace EarthdawnGamemasterAssistant.CharacterGenerator.Racial
{
    public interface IRace
    {
        int KarmaModifier { get; }
        int MovementRate { get; }

        IReadOnlyList<RacialAbility> GetRacialAbilities();

        int GetCarryingCapacity();

        Dexterity BaseDex { get; }
        Strength BaseStr { get; }
        Toughness BaseTou { get; }
        Perception BasePer { get; }
        Willpower BaseWil { get; }
        Charisma BaseCha { get; }
    }
}