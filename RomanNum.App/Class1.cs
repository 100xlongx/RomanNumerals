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
            {'M', 1000},
        };

        public static int Convert(string roman)
        {
            if (roman == null) {
                throw new ArgumentNullException();
            }

            foreach (char c in roman) {
                if (!romanMap.ContainsKey(c)) {
                    throw new ApplicationException("Invalid Input");
                }
            }

            var storage = 0;

            for (int i = 0; i < roman.Length; i++) {
                if (i + 1 < roman.Length && romanMap[roman[i]] < romanMap[roman[i + 1]]) {
                    storage -= romanMap[roman[i]];
                } else {
                    storage += romanMap[roman[i]];
                }
            }
            return storage;
        }
    
}
