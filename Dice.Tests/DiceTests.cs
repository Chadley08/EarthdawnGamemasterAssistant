using EarthdawnGamemasterAssistant.CharacterGenerator;
using EarthdawnGamemasterAssistant.CharacterGenerator.Dice;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Dice.Tests
{
    [TestClass]
    public class DiceTests
    {
        [TestMethod]
        public void check_non_exploding_die()
        {
            // Arrange
            var resultIs5 = 5;

            // Act
            var testDice = new Die(8);
            var result = testDice.Roll();

            // Assert
        }

        [TestMethod]
        public void check_exploding_die()
        {
            // Arrange

            // Act
            for (var i = 0; i < 600; i++)
            {
                var testDice = new Die(6);
                testDice.Roll();
            }
        }

        [TestMethod]
        public void parse_action_dice()
        {
            // Arrange
            var test = new List<List<int>>();

            // Act
            for (int i = 0; i < 41; i++)
            {
                test.Add(CharacteristicTables.ParseActionDice(i));
            }
        }
    }
}