using System.Collections.Generic;
using EarthdawnGamemasterAssistant;
using EarthdawnGamemasterAssistant.Attributes;
using EarthdawnGamemasterAssistant.Racial;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Creation.Tests
{
    [TestClass]
    public class CharacterCreationTests
    {
        [TestMethod]
        public void create_a_character()
        {
            // Arrange
            var testDwarf = Dwarf.CreateUsingDefaults();

            // Act

            // Assert
        }
    }
}