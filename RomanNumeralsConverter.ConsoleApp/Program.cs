using RomanNumeralsConverter.Core;
using System;

namespace RomanNumeralsConverter.ConsoleApp
{
    internal class Program
    {
        static void Main()
        {
            while(true)
            {
                Console.Write("Please enter an integer: ");
                var input = Console.ReadLine();
                if (!int.TryParse(input, out var number))
                {
                    Console.WriteLine("Not a valid integer.");
                    Console.WriteLine();
                    continue;
                }

                try
                {
                    var romanNumeral = RomanNumeralsConvert.FromNumber(number);
                    Console.WriteLine($"Roman numeral: {romanNumeral}");
                    Console.WriteLine();
                }
                catch (NumberOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                }
                catch (Exception ex)
                {
                    // Log ex
                    Console.WriteLine("Unknown exception");
                    Console.WriteLine();
                }
            }
        }
    }
}
