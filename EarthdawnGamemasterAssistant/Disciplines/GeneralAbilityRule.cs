using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarthdawnGamemasterAssistant.Disciplines
{
    public class GeneralAbilityRule : AbilityRule
    {
        public GeneralAbilityRule(int circleRequirement, int bonusAmount, string description) : base(circleRequirement, bonusAmount, description)
        {
        }
    }
}
