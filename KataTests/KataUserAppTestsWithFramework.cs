using Kata1_RoyOsherove;
using Moq;
using System.Collections.Generic;
using Xunit;

public class KataUserAppTests
{
    private ILogger logger;
    private ILogger bad_logger;
    private IWebService webService;
    private IInput input;


    [Theory]
    [InlineData("")]
    public void AppShouldGetInputsUntilEscapeCharIsPressed(string input)
    {
        
        var inputMock = mockUserInput(input);
        var loggerMock = mockLogger();
        var Calculator = mockStringCalculator();

        App app = new App(inputMock.Object, loggerMock.Object,Calculator.Object);
        app.run();
        Assert.True(app.userWantToExit);
    }

    [Theory]
    [InlineData("something")]
    public void verifyCalculatorEntry(string input)
    {

        var inputMock = mockUserInput("scalc "+input);
        var loggerMock = mockLogger();
        var Calculator = mockStringCalculator();

        App app = new App(inputMock.Object, loggerMock.Object, Calculator.Object);
        app.processEntry(inputMock.Object.GetInput());
        Calculator.Verify(m => m.Add(input), Times.AtLeastOnce());
    }




    private Mock<ILogger> mockLogger(string expected_Log = "any") {
        var mock = new Mock<ILogger>();
        if (expected_Log == "any") {
            mock.Setup((m) => m.Write(It.IsAny<string>())).Verifiable();
        }
        else {
            mock.Setup((m) => m.Write(expected_Log)).Verifiable();
        }
        return mock;
    }

    private Mock<IInput> mockUserInput(string input) {
        var mock = new Mock<IInput>();
        mock.Setup((m) => m.GetInput()).Returns(input);
        return mock;
    }

    private Mock<IStringCalculator> mockStringCalculator()
    {
        var mock = new Mock<IStringCalculator>();
        mock.Setup((m) => m.Add(It.IsAny<string>())).Returns(0).Verifiable();
        return mock;
    }
}
