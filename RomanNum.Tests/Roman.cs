using System;
using Xunit;
using RomanNum.App;
using FluentAssertions;
using System.Collections.Generic;
using Xunit.Sdk;

namespace RomanNum.Tests
{
    public class RomanConverterTests
    {
        [Fact]
        public void Convert_ShouldThrowException_WhenRomanIsNull()
        {
            string roman = null;

            Action action = () => RomanConverter.Convert(roman);

            action.Should().Throw<ArgumentNullException>();
        }
        
        [Fact]
        public void Convert_ShouldReturn0_WhenAnEmptyStringIsPassedIntoTheFunction()
        {
            string roman = "";
            int result = RomanConverter.Convert(roman);
            result.Should().Be(0);
        }

        [Fact]
        public void Convert_ShouldReturnConversion_WhenRomanHasOneValue()
        {
            //Given
            string roman = "V";
            //When
            var conversion = RomanConverter.Convert(roman);
            //Then
            conversion.Should().Be(5);
        }

        [Fact]
        public void Convert_ShouldReturnAnException_WhenRomanIsInvalid()
        {
        //Given
            string roman = "PICKLE RICK";
            Action action = () => RomanConverter.Convert(roman);
        //When

        //Then
            action.Should().Throw<ApplicationException>()
            .WithMessage("Invalid Input");
        }

        [Theory]
        [InlineData("IV", 4)]
        [InlineData("VI", 6)]
        [InlineData("X", 10)]
        [InlineData("XII", 12)]
        [InlineData("MCMXLIV", 1944)]
        public void Convert_ShouldReturnExpected_WhenGivenInput(string input, int expected)
        {
            int result = RomanConverter.Convert(input);
            result.Should().Be(expected);
        }
    }
}
