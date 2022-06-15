namespace RomanNumeralsConverter.Core
{
    public static class RomanNumeralsConvert
    {
        public static string FromNumber(int number)
        {
            ValidateNumber(number);
            return FromNumber(RomanNumeralDefinitionGenerator.MostSignificantDefinition, number);
        }

        private static string FromNumber(RomanNumeralDefinition definition, int number)
        {
            if (number == 0)
            {
                return string.Empty;
            }

            if (number >= definition.Number)
            {
                var remaining = number - definition.Number;
                var remainingRomanNumeral = FromNumber(definition, remaining);
                return $"{definition.RomanNumeral}{remainingRomanNumeral}";
            }
            else if (number >= definition.Number - definition.SubtractiveDefinition.Number)
            {
                var remaining = number - (definition.Number - definition.SubtractiveDefinition.Number);
                var remainingRomanNumeral = FromNumber(definition.LessSignificantDefinition, remaining);
                return $"{definition.SubtractiveDefinition.RomanNumeral}{definition.RomanNumeral}{remainingRomanNumeral}";
            }
            else
            {
                return FromNumber(definition.LessSignificantDefinition, number);
            }
        }

        private static void ValidateNumber(int number)
        {
            if (number < Constants.MinValue || number > Constants.MaxValue)
            {
                throw new NumberOutOfRangeException();
            }
        }
    }
}
