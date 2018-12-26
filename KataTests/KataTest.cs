using Kata1_RoyOsherove;
using System;
using Xunit;

namespace KataTests
{
    public class KataTest
    {
        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        public void ShouldReturnZeroOnEmptyString(string numbers)
        {
            StringCalculator stringCalculator = new StringCalculator();
            Assert.Equal(0,stringCalculator.Add(numbers));
        }

        [Theory]
        [InlineData("2")]
        [InlineData("3")]
        public void ShouldReturnSameNumberOnOneNumberString(string numbers)
        {
            StringCalculator stringCalculator = new StringCalculator();
            Assert.Equal(int.Parse(numbers), stringCalculator.Add(numbers));
        }

        [Theory]
        [InlineData("2,4",6)]
        [InlineData("3,6",9)]
        public void ShouldReturnTheResultWithTwoNumberString(string numbers,int result)
        {
            StringCalculator stringCalculator = new StringCalculator();
            Assert.Equal(result, stringCalculator.Add(numbers));
        }

        [Theory]
        [InlineData("2,10,25,13", 50)]
        [InlineData("3,4,1,6,8", 22)]
        public void ShouldAddAUnknowNumberOfNumbers(string numbers, int result)
        {
            StringCalculator stringCalculator = new StringCalculator();
            Assert.Equal(result,stringCalculator.Add(numbers));
        }

        [Theory]
        [InlineData("2\n10,25\n13", 50)]
        [InlineData("3\n4,1\n6\n8", 22)]
        public void SupportDiferentDelimiters(string numbers, int result)
        {
            StringCalculator stringCalculator = new StringCalculator();
            Assert.Equal(result, stringCalculator.Add(numbers));
        }


        [Theory]
        [InlineData("//;\n0;2;10;25;13", 50)]
        [InlineData("3\n4,1\n6\n8", 22)]
        public void SupportCustomDelimiters(string numbers, int result)
        {
            StringCalculator stringCalculator = new StringCalculator();
            Assert.Equal(result, stringCalculator.Add(numbers));
        }

    }
}
