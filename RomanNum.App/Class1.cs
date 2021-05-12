using System;
using System.Collections.Generic;

namespace RomanNum.App
{
    public static class RomanConverter
    {
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
            var storage = 0;
            if (roman == null)
            {
                throw new ArgumentNullException();
            }

            for (int x = 0; x < roman.Length; x++)
            {
                if (!romanMap.ContainsKey(roman[x]))
                {
                    throw new ApplicationException("Invalid Input");
                }

                if (roman.Length > 1 && x + 1 < roman.Length && romanMap[roman[x]] < romanMap[roman[x + 1]])
                {
                    storage += romanMap[roman[x + 1]] - romanMap[roman[x]];
                    x++;
                }
                else
                {
                    storage += romanMap[roman[x]];
                }
            }

            return storage;
        }
    }
}

