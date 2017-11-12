using EarthdawnGamemasterAssistant.CharacterGenerator.AbilityRules;
using EarthdawnGamemasterAssistant.CharacterGenerator.Talents;
using System.Collections.Generic;
using System.ComponentModel;

namespace EarthdawnGamemasterAssistant.CharacterGenerator.Disciplines
{
    public interface IDiscipline : INotifyPropertyChanged
    {
        int DurabilityRating { get; }
        string Name { get; }
        int EarthdawnCircle { get; set; }
        string Description { get; }

        IReadOnlyList<string> ImportantAttributes { get; }

        IReadOnlyList<PhysicalDefenseAbilityRule> PhysicalDefenseAbilityRules { get; }

        IReadOnlyList<MysticDefenseAbilityRule> MysticDefenseAbilityRules { get; }
        IReadOnlyList<KarmaAbilityRule> KarmaAbilityRules { get; }
        IReadOnlyList<InitiativeAbilityRule> InitiativeAbilityRules { get; }
        IReadOnlyList<GeneralAbilityRule> GeneralAbilityRules { get; }
        IReadOnlyList<RecoveryTestAbilityRule> RecoveryTestAbilityRules { get; }
        IReadOnlyList<SocialDefenseAbilityRule> SocialDefenseAbilityRules { get; }

        IReadOnlyList<Talent> NoviceTalentOptions { get; }
        IReadOnlyList<Talent> JourneymanTalentOptions { get; }
        Talent FreeTalent { get; }
        IReadOnlyDictionary<int, List<Talent>> TalentsAtCircle { get; }
    }
}