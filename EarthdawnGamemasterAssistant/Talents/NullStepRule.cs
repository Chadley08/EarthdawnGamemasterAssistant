using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarthdawnGamemasterAssistant.CharacterGenerator.Talents
{
    public class NullStepRule : IStepRule
    {
        public int CalculateStep()
        {
            return 0;
        }
    }
}
