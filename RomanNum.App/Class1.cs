using System;
using System.Collections.Generic;

namespace RomanNum.App
{
    public static class RomanConverter
    {
        static Dictionary<string, int> romanMap = new Dictionary<string, int>()
        {
            {"I", 1},
            {"V", 5},
            {"X", 10},
            {"L", 50},
            {"C", 100},
            {"D", 500},
            {"M", 1000},
        };

        public static int Convert(string number) {
            if (number == null) {
                throw new ArgumentNullException();
            }

            foreach (char c in number) {
                if (!romanMap.ContainsKey(number)) {
                    throw new ApplicationException("Invalid Input");
                }
            }

            return romanMap[number];
        }
    }
}
