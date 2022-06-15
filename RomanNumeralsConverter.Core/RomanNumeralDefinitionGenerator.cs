namespace RomanNumeralsConverter.Core
{
    internal static class RomanNumeralDefinitionGenerator
    {
        private static readonly RomanNumeralDefinition _mostSignificantDefinitions;

        static RomanNumeralDefinitionGenerator()
        {
            var i = new RomanNumeralDefinition(1, 'I', default, default);
            var v = new RomanNumeralDefinition(5, 'V', i, i);
            var x = new RomanNumeralDefinition(10, 'X', i, v);
            var l = new RomanNumeralDefinition(50, 'L', x, x);
            var c = new RomanNumeralDefinition(100, 'C', x, l);
            var d = new RomanNumeralDefinition(500, 'D', c, c);
            var m = new RomanNumeralDefinition(1000, 'M', c, d);

            _mostSignificantDefinitions = m;
        }

        public static RomanNumeralDefinition MostSignificantDefinition
            => _mostSignificantDefinitions;
    }
}
