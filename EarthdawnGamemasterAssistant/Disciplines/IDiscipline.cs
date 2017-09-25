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
        Circle EarthdawnCircle { get; set; }
    }
}