using EarthdawnGamemasterAssistant.CharacterGenerator;
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
            var expectedStepForDivPath = 5;
            var expectedStepForModPath = 9;

            // Act
            int calculatedStepForDivPath = CharacteristicTables.GetStepFromValue(10);
            int calculatedStepForModPath = CharacteristicTables.GetStepFromValue(24);

            // Assert
            Assert.IsTrue(expectedStepForDivPath == calculatedStepForDivPath);
            Assert.IsTrue(expectedStepForModPath == calculatedStepForModPath);
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
            var toCheckForStep3 = CharacteristicTables.ParseActionDice(3);
            var toCheckForStep9 = CharacteristicTables.ParseActionDice(22);
            var toCheckForStep9Again = CharacteristicTables.ParseActionDice(23);

            // Assert
            Assert.IsTrue(toCheckForStep3[0] == actionDiceForStep3[0]);
            Assert.IsTrue(toCheckForStep3.Count == actionDiceForStep3.Count);

            Assert.IsTrue(toCheckForStep9[0] == actionDiceForStep9[0]);
            Assert.IsTrue(toCheckForStep9[1] == actionDiceForStep9[1]);
            Assert.IsTrue(toCheckForStep9.Count == actionDiceForStep9.Count);

            Assert.IsTrue(toCheckForStep9Again[0] == actionDiceForStep9[0]);
            Assert.IsTrue(toCheckForStep9Again[1] == actionDiceForStep9[1]);
            Assert.IsTrue(toCheckForStep9Again.Count == actionDiceForStep9.Count);
        }
    }
}