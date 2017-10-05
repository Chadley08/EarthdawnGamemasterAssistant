using System.Collections.Generic;
using EarthdawnGamemasterAssistant.CharacterGenerator.Attributes;

namespace EarthdawnGamemasterAssistant.CharacterGenerator.Racial
{
    public interface IRace
    {
        int KarmaModifier { get; }
        int MovementRate { get; }

        IReadOnlyList<RacialAbility> GetRacialAbilities();

        Dexterity BaseDex { get; }
        Strength BaseStr { get; }
        Toughness BaseTou { get; }
        Perception BasePer { get; }
        Willpower BaseWil { get; }
        Charisma BaseCha { get; }
    }
}