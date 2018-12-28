using Kata1_RoyOsherove;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KataTests.Mocks
{
    class FakeLogger : ILogger
    {
        private List<string> outputs = new List<string>();
        public void Write(string output)
        {
            outputs.Add(output);
        }

        public string verifyLastOutput() {
            return outputs.Last();
        }
    }

    class BadFakeLogger : ILogger
    {
        public void Write(string output)
        {
            throw new Exception("Logger exception!!");
        }
    }
}
