using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarthdawnGamemasterAssistant.Disciplines
{
    public class PhysicalDefenseAbilityRule : AbilityRule
    {
        public PhysicalDefenseAbilityRule(int circleRequirement, int bonusAmount, string description) : base(circleRequirement, bonusAmount, description)
        {
        }

        public override void Apply(CharacterInfo characterInfo)
        {
            
        }
    }
}
