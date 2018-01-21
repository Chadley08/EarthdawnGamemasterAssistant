using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using EarthdawnGamemasterAssistant.CharacterGenerator.Actions;
using EarthdawnGamemasterAssistant.CharacterGenerator.Attributes;
using EarthdawnGamemasterAssistant.CharacterGenerator.Talents;

namespace EarthdawnGamemasterAssistant.CharacterGenerator.Skills
{
    public class Skill : INotifyPropertyChanged
    {
        public string Name { get; }
        public string Description { get; }
        public EarthdawnAttribute BaseEarthdawnAttribute { get; }
        private int _rank;

        public int Rank
        {
            get => _rank;
            set
            {
                _rank = value;
                OnPropertyChanged();
            }
        }
        public IStepRule StepRule { get; }
        public ActionType Action { get; }
        public int Strain { get; }
        public SkillCategory Category { get; }

        public Skill(
            string name,
            string description,
            EarthdawnAttribute baseEarthdawnAttribute,
            int rank,
            IStepRule stepRule,
            ActionType action,
            int strain,
            SkillCategory category)
        {
            Name = name;
            Description = description;
            BaseEarthdawnAttribute = baseEarthdawnAttribute;
            Rank = rank;
            StepRule = stepRule;
            Action = action;
            Strain = strain;
            Category = category;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
