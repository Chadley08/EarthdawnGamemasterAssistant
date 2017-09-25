using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using EarthdawnGamemasterAssistant.Disciplines;

namespace EarthdawnGamemasterAssistant
{
    public class DisciplineSet
    {
        private List<IDiscipline> Disciplines { get; }
        public DisciplineSet(List<IDiscipline> disciplines)
        {
            Disciplines = disciplines;
        }

        public IDiscipline this[string key] => GetValue(key);

        private IDiscipline GetValue(string key)
        {
            return Disciplines.First(discipline => discipline.Name == key);
        }

        public int GetHighestCircle()
        {
            return Disciplines.Max(discipline => discipline.EarthdawnCircle.Value);
        }

        public int GetHighestDurabilityRating()
        {
            return Disciplines.Max(discipline => discipline.DurabilityRating);
        }

        public int GetHighestPhysicalDefenseBonus()
        {
            return 0;
        }
    }
}