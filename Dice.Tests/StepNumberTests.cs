using earthdawn_tabletop_player;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Dice.Tests
{
    [TestClass]
    public class StepNumberTests
    {
        [TestMethod]
        public void check_attribute_step_number_calculation()
        {
            // Arrange
            var charismaForDivPath = new Charisma(10);
            var charismaForModPath = new Charisma(24);
            var expectedStepForDivPath = 5;
            var expectedStepForModPath = 9;

            // Act
            //int calculatedStepForDivPath = charismaForDivPath.GetStepFromValue();
            //int calculatedStepForModPath = charismaForModPath.GetStepFromValue();

            //// Assert
            //Assert.IsTrue(expectedStepForDivPath == calculatedStepForDivPath);
            //Assert.IsTrue(expectedStepForModPath == calculatedStepForModPath);
        }

        [TestMethod]
        public void check_attribute_action_dice()
        {
            // Arrange
            var actionDiceForStep9 = new List<int>
            {
                8,
                6
            };
            var actionDiceForStep3 = new List<int>
            {
                3
            };

            // Act
            var charismaForStep9 = new Charisma(22);
            var charismaForStep9Again = new Charisma(23);
            var charismaForStep3 = new Charisma(3);

            //var toCheckForStep3 = charismaForStep3.GetActionDie();
            //var toCheckForStep9 = charismaForStep9.GetActionDie();
            //var toCheckForStep9Again = charismaForStep9Again.GetActionDie();

            //// Assert
            //Assert.IsTrue(toCheckForStep3[0] == actionDiceForStep3[0]);
            //Assert.IsTrue(toCheckForStep3.Count == actionDiceForStep3.Count);

            //Assert.IsTrue(toCheckForStep9[0] == actionDiceForStep9[0]);
            //Assert.IsTrue(toCheckForStep9[1] == actionDiceForStep9[1]);
            //Assert.IsTrue(toCheckForStep9.Count == actionDiceForStep9.Count);

            //Assert.IsTrue(toCheckForStep9Again[0] == actionDiceForStep9[0]);
            //Assert.IsTrue(toCheckForStep9Again[1] == actionDiceForStep9[1]);
            //Assert.IsTrue(toCheckForStep9Again.Count == actionDiceForStep9.Count);
        }
    }
}