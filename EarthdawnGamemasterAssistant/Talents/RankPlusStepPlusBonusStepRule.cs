using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarthdawnGamemasterAssistant.CharacterGenerator.Talents
{
    public class RankPlusStepPlusBonusStepRule : IStepRule
    {
        private int Bonus { get; }
        public RankPlusStepPlusBonusStepRule(int bonus)
        {
            Bonus = bonus;
        }

        public int CalculateStep(int talentRank, int attributeStep)
        {
            throw new NotImplementedException();
        }
    }
}
