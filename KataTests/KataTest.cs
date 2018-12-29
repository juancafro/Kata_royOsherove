using Kata1_RoyOsherove;
using KataTests.Mocks;
using System;
using System.Collections.Generic;
using Xunit;

namespace KataTests
{
    public class KataTest
    {
        private ILogger logger;
        private ILogger bad_logger;
        private IWebService webService;
        private IInput input;

        public KataTest() {
            logger = new FakeLogger();
            bad_logger = new BadFakeLogger(); 
            webService = new FakeWebService();
        }
        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        public void ShouldReturnZeroOnEmptyString(string numbers)
        {
            StringCalculator stringCalculator = new StringCalculator(logger,webService);
            Assert.Equal(0,stringCalculator.Add(numbers));
        }

        [Theory]
        [InlineData("2")]
        [InlineData("3")]
        public void ShouldReturnSameNumberOnOneNumberString(string numbers)
        {
            StringCalculator stringCalculator = new StringCalculator(logger,webService);
            Assert.Equal(int.Parse(numbers), stringCalculator.Add(numbers));
        }

        [Theory]
        [InlineData("2,4",6)]
        [InlineData("3,6",9)]
        public void ShouldReturnTheResultWithTwoNumberString(string numbers,int result)
        {
            StringCalculator stringCalculator = new StringCalculator(logger,webService);
            Assert.Equal(result, stringCalculator.Add(numbers));
        }

        [Theory]
        [InlineData("2,10,25,13", 50)]
        [InlineData("3,4,1,6,8", 22)]
        public void ShouldAddAUnknowNumberOfNumbers(string numbers, int result)
        {
            StringCalculator stringCalculator = new StringCalculator(logger,webService);
            Assert.Equal(result,stringCalculator.Add(numbers));
        }

        [Theory]
        [InlineData("2\n10,25\n13", 50)]
        [InlineData("3\n4,1\n6\n8", 22)]
        public void SupportDiferentDelimiters(string numbers, int result)
        {
            StringCalculator stringCalculator = new StringCalculator(logger,webService);
            Assert.Equal(result, stringCalculator.Add(numbers));
        }


        [Theory]
        [InlineData("//;\n0;2;10;25;13", 50)]
        [InlineData("3\n4,1\n6\n8", 22)]
        public void SupportCustomDelimiters(string numbers, int result)
        {
            StringCalculator stringCalculator = new StringCalculator(logger,webService);
            Assert.Equal(result, stringCalculator.Add(numbers));
        }

        [Theory]
        [InlineData("//;\n1000;2;10;25;13", 50)]
        [InlineData("1000\n4,1\n5\n8", 18)]
        public void ShouldntAddGreaterNumbersThan1000(string numbers, int result) {
            StringCalculator stringCalculator = new StringCalculator(logger,webService);
            Assert.Equal(result, stringCalculator.Add(numbers));
        }

        [Theory]
        [InlineData("//[****]\n1000****2****10****25****13", 50)]
        public void ShouldSupportDelimitiersWithDifferentLength(string numbers, int result)
        {
            StringCalculator stringCalculator = new StringCalculator(logger,webService);
            Assert.Equal(result, stringCalculator.Add(numbers));
        }

        [Theory]
        [InlineData("//[****][%%%][---]\n1000****2%%%10---25****13", 50)]
        public void ShouldSupportMultipleDelimitiersWithDifferentLength(string numbers, int result)
        {
            StringCalculator stringCalculator = new StringCalculator(logger,webService);
            Assert.Equal(result, stringCalculator.Add(numbers));
        }


        [Theory]
        [InlineData("2\n10,25\n13", 50)]
        [InlineData("3\n4,1\n6\n8", 22)]
        [InlineData("//[****][%%%][---]\n1000****2%%%10---25****13", 50)]
        public void LoggerShouldPrintTheResult(string numbers, int result) {
            StringCalculator stringCalculator = new StringCalculator(logger, webService);
            stringCalculator.Add(numbers);
            var fakeLogger = (FakeLogger)stringCalculator.logger;
            Assert.Equal("The result is "+result, fakeLogger.verifyLastOutput());
        }

        [Theory]
        [InlineData("//[****][%%%][---]\n1000****2%%%10---25****13", 50)]
        public void WebServiceShouldNotifyWhenLoggerFails(string numbers, int result)
        {
            StringCalculator stringCalculator = new StringCalculator(bad_logger, webService);
            stringCalculator.Add(numbers);
            var fakeWebService = (FakeWebService)stringCalculator.webService;
            Assert.Equal(1,fakeWebService.VerifyCalls());
        }

      

    }
}
