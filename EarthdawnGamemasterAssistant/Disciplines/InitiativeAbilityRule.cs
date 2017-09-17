using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarthdawnGamemasterAssistant.Disciplines
{
    public class InitiativeAbilityRule : AbilityRule
    {
        public InitiativeAbilityRule(int circleRequirement, int bonusAmount, string description) : base(circleRequirement, bonusAmount, description)
        {
        }
    }
}
