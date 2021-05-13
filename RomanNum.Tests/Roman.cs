using System;
using FluentAssertions;
using RomanNum.App;
using Xunit;

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
            var roman = "";
            Action action = () => RomanConverter.Convert(roman);
            //When

            //Then
            action.Should().Throw<ApplicationException>()
                .WithMessage("Input was empty.");
        }

        [Fact]
        public void Convert_ShouldReturnConversion_WhenRomanHasOneValue()
        {
            //Given
            var roman = "V";
            //When
            var conversion = RomanConverter.Convert(roman);
            //Then
            conversion.Should().Be(5);
        }


        [Fact]
        public void Convert_ShouldReturnAnException_WhenRomanIsInvalid()
        {
            //Given
            var roman = "PICKLE RICK";
            Action action = () => RomanConverter.Convert(roman);
            //When

            //Then
            action.Should().Throw<ApplicationException>()
                .WithMessage("Invalid Input");
        }

        [Fact]
        public void Convert_ShouldReturnAnException_WhenRomanIsNegative()
        {
            //Given
            var roman = "-IV";
            Action action = () => RomanConverter.Convert(roman);
            //When

            //Then
            action.Should().Throw<ApplicationException>()
                .WithMessage("Invalid Input");
        }

        [Fact]
        public void Convert_ShouldReturnAnException_WhenRomanCharactersAreLowerCase()
        {
            //Given
            var roman = "iv";
            Action action = () => RomanConverter.Convert(roman);
            //When

            //Then
            action.Should().Throw<ApplicationException>()
                .WithMessage("Invalid Input");
        }

        [Fact]
        public void Convert_ShouldReturnAnException_WhenRomanCharactersAreOutsideMaxInt()
        {
            //Given
            var roman = "MMMMCMXCIX";
            //When
            Action action = () => RomanConverter.Convert(roman);
            //Then
            action.Should().Throw<ApplicationException>()
                .WithMessage("Invalid Input");
        }

        [Fact]
        public void Convert_ShouldReturnAnException_WhenRomanTranslationIsNegative()
        {
            //Given
            var roman = "IIX";
            //When
            Action action = () => RomanConverter.Convert(roman);
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
        [InlineData("I", 1)]
        public void Convert_ShouldReturnExpected_WhenGivenInput(string input, int expected)
        {
            var result = RomanConverter.Convert(input);
            result.Should().Be(expected);
        }
    }
}