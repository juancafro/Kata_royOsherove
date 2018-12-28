using Kata1_RoyOsherove;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KataTests.Mocks
{

    class FakeUserInput : IInput
    {
        private int counter = 0;
        private List<string> presetInputs;
        private int lastEntry;
        public FakeUserInput(List<string> inputs) {
            presetInputs = inputs;
        }
        public string GetInput()
        {
            string currentInput = "";
            if (counter < presetInputs.Count) {
                currentInput = presetInputs[counter];
            }
            lastEntry = counter;
            counter++;
            return currentInput;
        }

        public int verifyCounter() {
            return counter;
        }

        public string GetLastInput() {
           return presetInputs[lastEntry];
        }
    }
}
