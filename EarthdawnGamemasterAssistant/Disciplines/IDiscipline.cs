using EarthdawnGamemasterAssistant.AbilityRules;
using EarthdawnGamemasterAssistant.Talents;
using System.Collections.Generic;
using System.ComponentModel;

namespace EarthdawnGamemasterAssistant.Disciplines
{
    public interface IDiscipline : INotifyPropertyChanged
    {
        int DurabilityRating { get; }
        string Name { get; }
        int EarthdawnCircle { get; set; }
        string Description { get; }

        // These need to be handled in an abstract Discipline class, not here.
        // They should be static references to these lists as the lists never change.
        IReadOnlyList<PhysicalDefenseAbilityRule> PhysicalDefenseAbilityRules { get; }

        IReadOnlyList<MysticDefenseAbilityRule> MysticDefenseAbilityRules { get; }
        IReadOnlyList<KarmaAbilityRule> KarmaAbilityRules { get; }
        IReadOnlyList<InitiativeAbilityRule> InitiativeAbilityRules { get; }
        IReadOnlyList<GeneralAbilityRule> GeneralAbilityRules { get; }
        IReadOnlyList<RecoveryTestAbilityRule> RecoveryTestAbilityRules { get; }
        IReadOnlyList<SocialDefenseAbilityRule> SocialDefenseAbilityRules { get; }

        IReadOnlyList<Talent> DisciplineTalents { get; }
        IReadOnlyList<Talent> NoviceTalentOptions { get; }
        IReadOnlyList<Talent> JourneymanTalentOptions { get; }
        Talent FreeTalent { get; }
    }
}