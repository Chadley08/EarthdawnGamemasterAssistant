using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarthdawnGamemasterAssistant.Disciplines
{
    public class Circle
    {
        public int Value { get; }
        public List<AbilityRule> CircleSpecificAbilities { get; }

        /// <summary>
        /// Circle currently contains only abilities available at the current circle selected for a given discipline.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="circleSpecificAbilities"></param>
        public Circle(int value, List<AbilityRule> circleSpecificAbilities)
        {
            Value = value;
            CircleSpecificAbilities = circleSpecificAbilities;
        }
    }
}
