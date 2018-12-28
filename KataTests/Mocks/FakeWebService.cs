using Kata1_RoyOsherove;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KataTests.Mocks
{
    public class FakeWebService : IWebService
    {
        private int callCounter = 0;

        public void Notify(string output)
        {
            callCounter++;       
        }

        public int VerifyCalls()
        {
            return callCounter;
        }
    }
}
