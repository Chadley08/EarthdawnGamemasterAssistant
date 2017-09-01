using System.Collections.Generic;
using EarthdawnGamemasterAssistant.Attributes;

namespace EarthdawnGamemasterAssistant.Racial
{
    public interface IRace
    {
        IReadOnlyList<RacialAbility> GetRacialAbilities();
        Dexterity BaseDex { get; }
        Strength BaseStr { get; }
        Toughness BaseTou { get; }
        Perception BasePer { get; }
        Willpower BaseWil { get; }
        Charisma BaseCha { get; }

    }
}