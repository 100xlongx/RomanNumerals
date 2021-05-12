using System;
using Xunit;
using RomanNum.App;
using FluentAssertions;
using System.Collections.Generic;
using Xunit.Sdk;

namespace RomanNum.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void ConversionFunctionReturns()
        {
            string roman = null;

            Action action = () => RomanConverter.Convert(roman);

            action.Should().Throw<ArgumentNullException>();
        }
        
        [Fact]
        public void ZeroCase_ShouldReturn0()
        {
            string roman = "";
            int result = RomanConverter.Convert(roman);
            result.Should().Be(0);
        }

        [Fact]
        public void ConvertsSingleRomanNumeral()
        {
            //Given
            string roman = "V";
            //When
            var conversion = RomanConverter.Convert(roman);
            //Then
            conversion.Should().Be(5);
        }

        [Fact]
        public void HandlesInvalidInput()
        {
        //Given
            string roman = "PICKLE RICK";
            Action action = () => RomanConverter.Convert(roman);
        //When

        //Then
            action.Should().Throw<ApplicationException>()
            .WithMessage("Invalid Input");
        }
        
        [Fact]
        public void WhenGivenVI_ShouldReturn6()
        {
            int result = RomanConverter.Convert("VI");
            result.Should().Be(6);
        }
        
    }
}
