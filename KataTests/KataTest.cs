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

    }
}
