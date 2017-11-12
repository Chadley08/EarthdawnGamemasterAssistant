﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarthdawnGamemasterAssistant.CharacterGenerator.Talents
{
    public class RankPlusAttributeStepRule : IStepRule
    {
        public int CalculateStep(int talentRank, int attributeStep)
        {
            return talentRank + attributeStep;
        }
    }
}
