using NUnit.Framework;
using RomanNumeralsConverter.Core;
using System.Collections.Generic;
using System.Linq;

namespace RomanNumeralsConverter.Tests
{
    public class RomanNumeralDefinitionGeneratorTests
    {
        private List<RomanNumeralDefinition> _allDefinitions;

        [SetUp]
        public void Setup()
        {
            _allDefinitions = new List<RomanNumeralDefinition>();
            var definition = RomanNumeralDefinitionGenerator.MostSignificantDefinition;
            while (definition != default)
            {
                _allDefinitions.Add(definition);
                definition = definition.LessSignificantDefinition;
            }
        }

        [Test]
        public void MostSignificant_should_not_have_moreSignificant()
        {
            // Arrange
            var mostSignificant =
                _allDefinitions
                .OrderByDescending(d => d.Number)
                .First();

            // Act
            var actual = mostSignificant.MoreSignificantDefinition;

            // Assert
            Assert.That(actual, Is.Null);
        }

        [Test]
        public void LeastSignificant_should_not_have_lessSignificant()
        {
            // Arrange
            var leastSignificant =
                _allDefinitions
                .OrderBy(d => d.Number)
                .First();

            // Act
            var actual = leastSignificant.LessSignificantDefinition;

            // Assert
            Assert.That(actual, Is.Null);
        }

        [Test]
        public void SubtractiveTests()
        {
            SubtractiveTest('I', 'V', 'X');
            SubtractiveTest('X', 'L', 'C');
            SubtractiveTest('C', 'D', 'M');
        }

        private void SubtractiveTest(char subtractiveRomanNumeral, char smallDefinition, char largeDefinition)
        {
            // Arrange
            var definitions =
                _allDefinitions
                .Where(d => d.SubtractiveDefinition?.RomanNumeral == subtractiveRomanNumeral)
                .OrderBy(d => d.Number)
                .ToList();

            // Act
            var actual_1 = definitions[0].RomanNumeral;
            var actual_2 = definitions[1].RomanNumeral;

            // Assert
            Assert.That(definitions.Count, Is.EqualTo(2));
            Assert.That(actual_1, Is.EqualTo(smallDefinition));
            Assert.That(actual_2, Is.EqualTo(largeDefinition));
        }
    }
}
