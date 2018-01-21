using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using EarthdawnGamemasterAssistant.CharacterGenerator.Actions;
using EarthdawnGamemasterAssistant.CharacterGenerator.Attributes;
using EarthdawnGamemasterAssistant.CharacterGenerator.Skills;

namespace EarthdawnGamemasterAssistant.CharacterGenerator.Talents
{
    public static class TalentTable
    {
        private static List<Talent> Talents => new List<Talent>
        {
            new Talent("Acrobatic Defense", "", new Dexterity(0), 0, new RankPlusAttributeStepRule(),  new SimpleAction(), 1, true, ""),
            new Talent("Air Dance", "", new Dexterity(0), 0,new RankPlusAttributeStepRule(),  new FreeAction(), 2, false, ""),
            new Talent("Air Speaking", "", new Perception(0), 0,new RankPlusAttributeStepRule(),  new SimpleAction(), 1, false, ""),
            new Talent("Anticipate Blow", "", new Perception(0), 0,new RankPlusAttributeStepRule(),  new SimpleAction(), 1, true, ""),
            new Talent("Avoid Blow", "", new Dexterity(0), 0,new RankPlusAttributeStepRule(),  new FreeAction(), 1, true, ""),
            new Talent("Awareness", "", new Perception(0), 0,new RankPlusAttributeStepRule(),  new SimpleAction(), 0, true, ""),
            new Talent("Bank Shot", "", new Dexterity(0), 0,new RankPlusAttributeStepRule(),  new SimpleAction(), 1, false, ""),
            new Talent("Battle Bellow", "", new Charisma(0), 0,new RankPlusAttributeStepRule(),  new SimpleAction(), 1, true, ""),
            new Talent("Climbing", "", new Dexterity(0), 0,new RankPlusAttributeStepRule(),  new StandardAction(), 0, true, ""),
            new Talent("Conceal Object", "", new Dexterity(0), 0,new RankPlusAttributeStepRule(),  new StandardAction(), 1, true, ""),
            new Talent("Conversation", "", new Charisma(0), 0,new RankPlusAttributeStepRule(),  new SustainedAction(), 0, true, ""),
            new Talent("Creature Analysis", "", new Perception(0), 0,new RankPlusAttributeStepRule(),  new SimpleAction(), 1, false, ""),
            new Talent("Danger Sense", "", new Dexterity(0), 0,new RankPlusAttributeStepRule(),  new FreeAction(), 1, true, ""),
            new Talent("Distract", "", new Charisma(0), 0,new RankPlusAttributeStepRule(),  new SimpleAction(), 1, true, ""),
            new Talent("Empathic Sense", "", new Charisma(0), 0,new RankPlusAttributeStepRule(),  new FreeAction(), 1, true, ""),
            new Talent("Engaging Banter", "", new Charisma(0), 0,new RankPlusAttributeStepRule(),  new StandardAction(), 0, true, ""),
            new Talent("Etiquette", "", new Charisma(0), 0,new RankPlusAttributeStepRule(),  new SustainedAction(), 0, true, ""),
            new Talent("Evidence Analysis", "", new Perception(0), 0,new RankPlusAttributeStepRule(),  new SustainedAction(), 1, true, ""),
            new Talent("First Impression", "", new Charisma(0), 0,new RankPlusAttributeStepRule(),  new StandardAction(), 0, true, ""),
            new Talent("Flame Arrow", "", new Willpower(0), 0,new RankPlusAttributeStepRule(),  new FreeAction(), 1, false, ""),
            new Talent("Graceful Exit", "", new Charisma(0), 0,new RankPlusAttributeStepRule(),  new StandardAction(), 0, true, ""),
            new Talent("Great Leap", "", new Dexterity(0), 0,new RankPlusAttributeStepRule(),  new FreeAction(), 1, true, ""),
            new Talent("Haggle", "", new Charisma(0), 0,new RankPlusAttributeStepRule(),  new SustainedAction(), 0, true, ""),
            new Talent("Heartening Laugh", "", new Charisma(0), 0,new RankPlusAttributeStepRule(),  new SimpleAction(), 1, true, ""),
            new Talent("Impressive Display", "", new NullAttribute(), 0,new RankPlusAttributeStepRule(),  new SimpleAction(), 1, true, ""),
            new Talent("Inspire Others", "", new Charisma(0), 0,new RankPlusAttributeStepRule(),  new StandardAction(), 0, false, ""),
            new Talent("Leadership", "", new Charisma(0), 0,new RankPlusAttributeStepRule(),  new SustainedAction(), 0, true, ""),
            new Talent("Lion Heart", "", new Willpower(0), 0,new RankPlusAttributeStepRule(),  new FreeAction(), 1, false, ""),
            new Talent("Long Shot", "", new NullAttribute(), 0,new RankPlusAttributeStepRule(),  new SimpleAction(), 1, false, ""),
            new Talent("Maneuver", "", new Dexterity(0), 0,new RankPlusAttributeStepRule(),  new SimpleAction(), 1, true, ""),
            new Talent("Melee Weapons", "", new Dexterity(0), 0,new RankPlusAttributeStepRule(),  new StandardAction(), 0, true, ""),
            new Talent("Missile Weapons", "", new Dexterity(0), 0,new RankPlusAttributeStepRule(),  new StandardAction(), 0, true, ""),
            new Talent("Mystic Aim", "", new Perception(0), 0,new RankPlusAttributeStepRule(),  new SimpleAction(), 1, false, ""),
            new Talent("Mystic Pursuit", "", new Perception(0), 0,new RankPlusAttributeStepRule(),  new StandardAction(), 2, false, ""),
            new Talent("Navigation", "", new Perception(0), 0,new RankPlusAttributeStepRule(),  new SustainedAction(), 0, true, ""),
            new Talent("Resist Taunt", "", new Willpower(0), 0,new RankPlusAttributeStepRule(),  new FreeAction(), 1, true, ""),
            new Talent("Second Shot", "", new Dexterity(0), 0,new RankPlusAttributeStepRule(),  new SimpleAction(), 2, true, ""),
            new Talent("Second Weapon", "", new Dexterity(0), 0,new RankPlusAttributeStepRule(),  new SimpleAction(), 1, true, ""),
            new Talent("Speak Language", "", new Perception(0), 0,new RankPlusAttributeStepRule(),  new StandardAction(), 1, false, ""),
            new Talent("Spot Armor Flaw", "", new Perception(0), 0,new RankPlusAttributeStepRule(),  new SimpleAction(), 1, false, ""),
            new Talent("Stealthy Stride", "", new Dexterity(0), 0,new RankPlusAttributeStepRule(),  new SimpleAction(), 0, true, ""),
            new Talent("Steel Thought", "", new Willpower(0), 0,new RankPlusAttributeStepRule(),  new FreeAction(), 1, false, ""),
            new Talent("Stopping Aim", "", new Charisma(0), 0,new RankPlusAttributeStepRule(),  new StandardAction(), 1, false, ""),
            new Talent("Surprise Strike", "", new Strength(0), 0,new RankPlusAttributeStepRule(),  new FreeAction(), 1, true, ""),
            new Talent("Taunt", "", new Charisma(0), 0,new RankPlusAttributeStepRule(),  new SimpleAction(), 1, true, ""),
            new Talent("Thread Weaving (Air Weaving)", "", new Perception(0), 0, new RankPlusAttributeStepRule(), new StandardAction(), 0, false, ""),
            new Talent("Thread Weaving (Arrow Weaving)", "", new Perception(0), 0,new RankPlusAttributeStepRule(),  new StandardAction(), 0, false, ""),
            new Talent("Throwing Weapons", "", new Dexterity(0), 0,new RankPlusAttributeStepRule(),  new StandardAction(), 0, true, ""),
            new Talent("Tiger Spring", "", new NullAttribute(), 0,new RankPlusAttributeStepRule(),  new FreeAction(), 1, false, ""),
            new Talent("Tracking", "", new Perception(0), 0,new RankPlusAttributeStepRule(),  new StandardAction(), 0, true, ""),
            new Talent("True Shot", "", new NullAttribute(), 0,new RankPlusAttributeStepRule(),  new FreeAction(), 2, false, ""),
            new Talent("Wilderness Survival", "", new Perception(0), 0,new RankPlusAttributeStepRule(),  new SustainedAction(), 0, true, ""),
            new Talent("Wind Catcher", "", new Willpower(0), 0,new RankPlusAttributeStepRule(),  new StandardAction(), 1, false, ""),
            new Talent("Wound Balance", "", new Strength(0), 0,new RankPlusAttributeStepRule(),  new FreeAction(), 0, true, ""),

        };

        public static List<Talent> CreateTalentsByName(List<string> talentNames)
        {
            return Talents.Join(
                talentNames,
                talent => talent.Name,
                s => s,
                ((talent, s) => new Talent(
                    talent.Name,
                    talent.Description,
                    talent.BaseEarthdawnAttribute,
                    talent.Rank,
                    talent.StepRule,
                    talent.Action,
                    talent.Strain,
                    talent.SkillUse,
                    talent.SkillDescription))).ToList();
        }

        public static Talent GetTalentByName(string talentName)
        {
            return Talents.Find(talent => talent.Name == talentName);
        }
    }
}
