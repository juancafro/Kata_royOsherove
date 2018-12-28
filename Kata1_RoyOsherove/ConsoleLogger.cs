using System;
using System.Collections.Generic;
using System.Text;

namespace Kata1_RoyOsherove
{
    class ConsoleLogger : ILogger
    {
        public void Write(string output)
        {
            Console.WriteLine(output);
        }
    }
}
