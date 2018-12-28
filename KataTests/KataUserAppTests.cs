using Kata1_RoyOsherove;
using KataTests.Mocks;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace KataTests
{
    public class KataUserAppTests
    {
        private ILogger logger;
        private ILogger bad_logger;
        private IWebService webService;
        private IInput input;

        public KataUserAppTests()
        {
            logger = new FakeLogger();
            bad_logger = new BadFakeLogger();
            webService = new FakeWebService();
        }

        [Fact]
        public void AppShouldGetInputsUntilEscapeCharIsPressed()
        {
            List<string> inputs = new List<string>();
            inputs.Add("something");
            inputs.Add("something");
            inputs.Add("something");
            inputs.Add("something");
            inputs.Add("");
            inputs.Add("something that doesn't suppose to exist");

            input = new FakeUserInput(inputs);
            App app = new App(input, logger, new FakeStringCalculator());
            app.run();
            var fakeInput = (FakeUserInput)app.input;
            Assert.Equal("", fakeInput.GetLastInput());
        }

        [Fact]
        public void AppShouldCallStringCalculatorWhenFindKeyword()
        {
            List<string> inputs = new List<string>();
            inputs.Add("something");
            inputs.Add("scalc something");
            inputs.Add("something");
            inputs.Add("scalc something");

            input = new FakeUserInput(inputs);
            App app = new App(input, logger, new FakeStringCalculator());
            app.run();
            var fakeInput = (FakeStringCalculator) app.stringCalculator;
            Assert.Equal(2, fakeInput.VerifyCalls());
        }

        [Theory]
        [InlineData("//[****][%%%][---]\n1000****2%%%10---25****13")]
        [InlineData("//;\n1000;2;10;25;13")]
        public void AppShouldPassTheCorrectStringToCalculator(string Calcinput)
        {
            List<string> inputs = new List<string>();
            inputs.Add("scalc "+Calcinput);

            input = new FakeUserInput(inputs);
            App app = new App(input, logger, new FakeStringCalculator());
            app.run();
            var fakeCalculator = (FakeStringCalculator)app.stringCalculator;
            Assert.Equal(Calcinput, fakeCalculator.VerifyLastInput());
        }
    }
}
