using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EarthdawnGamemasterAssistant.Actions;
using EarthdawnGamemasterAssistant.Attributes;

namespace EarthdawnGamemasterAssistant.Talents
{
    public class NullTalent : Talent
    {
        public NullTalent() : base("", "", new NullAttribute(), 0, new NullAction(), 0, false)
        {
        }
    }
}
