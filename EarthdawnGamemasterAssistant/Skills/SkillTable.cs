using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EarthdawnGamemasterAssistant.CharacterGenerator.Actions;
using EarthdawnGamemasterAssistant.CharacterGenerator.Attributes;
using EarthdawnGamemasterAssistant.CharacterGenerator.Talents;

namespace EarthdawnGamemasterAssistant.CharacterGenerator.Skills
{
    public static class SkillTable
    {
        public static IReadOnlyList<Skill> Skills => new List<Skill>
        {
            new Skill("Animal Handling", "", new Willpower(0), 0, new RankPlusAttributeStepRule(), new StandardAction(), 1, SkillCategory.Default),
            ConvertFromTalent("Avoid Blow"),
            ConvertFromTalent("Awareness"),
            ConvertFromTalent("Bribery"),
            ConvertFromTalent("Climbing"),
            ConvertFromTalent("Conversation"),
            ConvertFromTalent("Distract"),
            ConvertFromTalent("Etiquette"),
            new Skill("Flirting","", new Charisma(0),0, new RankPlusAttributeStepRule(), new FreeAction(), 0, SkillCategory.Default),
            ConvertFromTalent("Haggle"),
            ConvertFromTalent("Melee Weapons"),
            ConvertFromTalent("Missle Weapons"),
            new Skill("Research","", new Perception(0), 0, new RankPlusAttributeStepRule(), new FreeAction(), 0, SkillCategory.Default),
            ConvertFromTalent("Resist Taunt"),
            new Skill("Seduction","", new Charisma(0),0, new RankPlusAttributeStepRule(), new FreeAction(), 0, SkillCategory.Default),
            new Skill("Slough Blame","", new Charisma(0),0, new RankPlusAttributeStepRule(), new FreeAction(), 0, SkillCategory.Default),
            new Skill("Swimming","", new Dexterity(0), 0, new RankPlusAttributeStepRule(), new SustainedAction(), 0, SkillCategory.Default),
            ConvertFromTalent("Throwing Weapons"),
            ConvertFromTalent("Tracking"),
            ConvertFromTalent("Unarmed Combat"),
            ConvertFromTalent("Wilderness Survival")
        };

        public static List<Skill> CreateSkillsByName(List<string> skillNames)
        {
            return Skills.Join(
                skillNames,
                skill => skill.Name,
                s => s,
                ((skill, s) => new Skill(
                    skill.Name,
                    skill.Description,
                    skill.BaseEarthdawnAttribute,
                    skill.Rank,
                    skill.StepRule,
                    skill.Action,
                    skill.Strain,
                    skill.Category))).ToList();
        }

        public static Skill ConvertFromTalent(string talentName)
        {
            var talent = TalentTable.GetTalentByName(talentName);
            return new Skill(talent.Name, talent.SkillDescription, talent.BaseEarthdawnAttribute, talent.Rank, talent.StepRule, talent.Action, talent.Strain, SkillCategory.Free);
        }
    }
}
