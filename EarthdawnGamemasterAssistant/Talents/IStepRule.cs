using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarthdawnGamemasterAssistant.CharacterGenerator.Talents
{
    public interface IStepRule
    {
        int CalculateStep(int talentRank, int attributeStep);
    }
}
