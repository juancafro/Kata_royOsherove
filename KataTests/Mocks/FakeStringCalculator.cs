using Kata1_RoyOsherove;
using System;
using System.Collections.Generic;
using System.Text;

namespace KataTests.Mocks
{
    class FakeStringCalculator : IStringCalculator
    {
        private int callCounter = 0;
        private string lastInput;

        public int Add(string numbers)
        {
            lastInput = numbers;
            callCounter++;
            return 0;
        }

        public int VerifyCalls()
        {
            return callCounter;
        }

        public string VerifyLastInput()
        {
            return lastInput;
        }
    }
}
