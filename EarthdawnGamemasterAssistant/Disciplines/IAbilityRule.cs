using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarthdawnGamemasterAssistant.Disciplines
{
    public interface IAbilityRule
    {
        int BonusAmount { get; }
        string Description { get; }
    }
}
