namespace RomanNumeralsConverter.Core
{
    internal class RomanNumeralDefinition
    {
        public readonly int Number;
        public readonly char RomanNumeral;
        public readonly RomanNumeralDefinition SubtractiveDefinition;
        public readonly RomanNumeralDefinition LessSignificantDefinition;
        public RomanNumeralDefinition MoreSignificantDefinition { get; private set; }

        public RomanNumeralDefinition(
            int number,
            char romanNumeral,
            RomanNumeralDefinition subtractiveDefinition,
            RomanNumeralDefinition lessSignificantDefinition)
        {
            Number = number;
            RomanNumeral = romanNumeral;
            SubtractiveDefinition = subtractiveDefinition;
            LessSignificantDefinition = lessSignificantDefinition;
            if (lessSignificantDefinition != default)
            {
                lessSignificantDefinition.MoreSignificantDefinition = this;
            }
        }
    }
}
