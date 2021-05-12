using System;
using Xunit;

namespace RomanNum.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            string roman = "V";

            var conversion = RomanConverter.Convert(roman);
        }
    }
}
