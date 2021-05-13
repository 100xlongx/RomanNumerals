using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RomanNum.App
{
    public static class RomanConverter
    {

        const int MAX_VALUE = 4999;
        const string RomanValidator = "^M{0,3}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$";

        static Regex rx = new Regex(@"^M{0,3}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$");

        static Dictionary<char, int> romanMap = new Dictionary<char, int>()
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
            if (roman == null)
            {
                throw new ArgumentNullException();
            }

            if (roman == String.Empty) {
                throw new ApplicationException("Input was empty.");
            }

            if(!rx.IsMatch(roman)) {
                throw new ApplicationException("Invalid Input");
            }

            var storage = 0;

            for (int x = 0; x < roman.Length; x++)
            {
                if (!romanMap.ContainsKey(roman[x]))
                {
                    throw new ApplicationException("Invalid Input");
                }

                if (x + 1 < roman.Length && romanMap[roman[x]] < romanMap[roman[x + 1]]) {
                    storage -= romanMap[roman[x]];
                } else {
                    storage += romanMap[roman[x]];
                }

                if (storage > MAX_VALUE) {
                    throw new ApplicationException("Value is above maximum allowed input");
                }
            }

            return storage;
        }
    }
}

