using System;

namespace Kata1_RoyOsherove
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            IInput input = new ConsoleUserInput();
            ILogger logger = new ConsoleLogger();
            IWebService webService = new ConsoleWebService();
            IStringCalculator stringCalculator = new StringCalculator(logger,webService);

            App app = new App(input, logger, stringCalculator);
            app.run();

        }
    }
}
