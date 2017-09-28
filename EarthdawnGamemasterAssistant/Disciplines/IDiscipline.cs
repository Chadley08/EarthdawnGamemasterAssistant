using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using EarthdawnGamemasterAssistant.Annotations;
using EarthdawnGamemasterAssistant.Talents;

namespace EarthdawnGamemasterAssistant.Disciplines
{
    public interface IDiscipline : INotifyPropertyChanged
    {
        int DurabilityRating { get; }
        string Name { get; }
        int EarthdawnCircle { get; set; }
        IReadOnlyList<PhysicalDefenseAbilityRule> PhysicalDefenseAbilityRules { get; }
    }
}