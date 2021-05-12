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

        public static int Convert(string number)
        {
            var storage = 0;
            if (number == null) {
                throw new ArgumentNullException();
            }

            foreach (char c in number) {
                if (!romanMap.ContainsKey(c.ToString())) {
                    throw new ApplicationException("Invalid Input");
                }

                storage += romanMap[c.ToString()];
            }
            
            
            return storage;
        }
    }
}
