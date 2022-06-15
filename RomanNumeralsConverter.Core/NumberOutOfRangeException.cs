using System;

namespace RomanNumeralsConverter.Core
{
    public class NumberOutOfRangeException : Exception
    {
        public NumberOutOfRangeException()
            : base($"Number can be between {Constants.MinValue} and {Constants.MaxValue}, inclusive.")
        {
        }
    }
}
