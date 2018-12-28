using System;
using System.Collections.Generic;
using System.Text;

namespace Kata1_RoyOsherove
{
    public class App
    {
        public IInput input;
        public ILogger logger;
        public IStringCalculator stringCalculator;

        public App(IInput input,ILogger logger,IStringCalculator stringCalculator) {
            this.input = input;
            this.logger = logger;
            this.stringCalculator = stringCalculator;
        }

        public void run() {
            bool userWantToExit = false;
            logger.Write("write scalc [your_entry] to use the calculator");
            while (!userWantToExit)
            {
                string inputstring = input.GetInput();
                if (inputstring.Equals("") || inputstring.Equals(" "))
                {
                    userWantToExit = true;
                }
                else {
                    string[] userInputParts = inputstring.Split(' ');
                    if (userInputParts[0] == "scalc") {
                        stringCalculator.Add(userInputParts[1]);
                    }
                    logger.Write("another input please");
                }
            }
        }
    }
}
