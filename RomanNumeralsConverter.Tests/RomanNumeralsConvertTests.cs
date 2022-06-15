using NUnit.Framework;
using RomanNumeralsConverter.Core;
using System.Collections.Generic;

namespace RomanNumeralsConverter.Tests
{
    public class RomanNumeralsConvertTests
    {
        [Test]
        public void ConvertToRomanNumeral_OutOfRange_Tests()
        {
            // Arrange
            var outOfRangeNumbers = new List<int> { 0, -5, 2001, 1000000 };

            // Act
            // Assert
            foreach (var number in outOfRangeNumbers)
            {
                Assert.Throws<NumberOutOfRangeException>(() => RomanNumeralsConvert.FromNumber(number));
            }
        }

        [Test]
        public void ConvertToRomanNumeral_InTheRange_Tests()
        {
            // Arrange
            var inTheRangeNumbers = new List<int> { 1, 5, 499, 2000 };

            // Act
            // Assert
            foreach (var number in inTheRangeNumbers)
            {
                Assert.DoesNotThrow(() => RomanNumeralsConvert.FromNumber(number));
            }
        }

        [Test]
        public void FromNumber_Definition_Tests()
        {
            // Arrange
            var tuples = new List<(int number, string expectedRomanNumeral)>
            {
                (number: 1, expectedRomanNumeral: "I"),
                (number: 5, expectedRomanNumeral: "V"),
                (number: 10, expectedRomanNumeral: "X"),
                (number: 50, expectedRomanNumeral: "L"),
                (number: 100, expectedRomanNumeral: "C"),
                (number: 500, expectedRomanNumeral: "D"),
                (number: 1000, expectedRomanNumeral: "M"),
            };
            
            foreach (var (number, expectedRomanNumeral) in tuples)
            {
                // Act
                var actual = RomanNumeralsConvert.FromNumber(number);

                // Assert
                var expected = expectedRomanNumeral;
                Assert.That(actual, Is.EqualTo(expected));
            }
        }

        [Test]
        public void FromNumber_Calculation_Tests()
        {
            // Arrange
            var tuples = new List<(int number, string expectedRomanNumeral)>
            {
                (number: 2, expectedRomanNumeral: "II"),
                (number: 3, expectedRomanNumeral: "III"),
                (number: 6, expectedRomanNumeral: "VI"),
                (number: 11, expectedRomanNumeral: "XI"),
                (number: 16, expectedRomanNumeral: "XVI"),
                (number: 4, expectedRomanNumeral: "IV"),
                (number: 45, expectedRomanNumeral: "XLV"),
                (number: 99, expectedRomanNumeral: "XCIX"),
                (number: 845, expectedRomanNumeral: "DCCCXLV"),
                (number: 999, expectedRomanNumeral: "CMXCIX"),
                (number: 1999, expectedRomanNumeral: "MCMXCIX"),
            };

            foreach (var (number, expectedRomanNumeral) in tuples)
            {
                // Act
                var actual = RomanNumeralsConvert.FromNumber(number);

                // Assert
                var expected = expectedRomanNumeral;
                Assert.That(actual, Is.EqualTo(expected));
            }
        }
    }
}
