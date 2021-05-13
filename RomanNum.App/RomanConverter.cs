using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RomanNum.App
{
    public static class RomanConverter
    {
        private const int MAX_VALUE = 4999;
        private static readonly Regex Rx = new(@"^M{0,3}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$");

        private static readonly Dictionary<char, int> RomanMap = new()
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };

        public static int Convert(string roman)
        {
            if (roman == null) throw new ArgumentNullException();

            if (roman == string.Empty) throw new ApplicationException("Input was empty.");

            if (!Rx.IsMatch(roman)) throw new ApplicationException("Invalid Input");

            var storage = 0;

            for (var x = 0; x < roman.Length; x++)
            {

                if (x + 1 < roman.Length && RomanMap[roman[x]] < RomanMap[roman[x + 1]])
                    storage -= RomanMap[roman[x]];
                else
                    storage += RomanMap[roman[x]];
                
            }

            return storage;
        }
    }
}