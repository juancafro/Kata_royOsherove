using System;
using System.Collections.Generic;
using System.Text;

namespace Kata1_RoyOsherove
{
    class ConsoleWebService : IWebService
    {
        public void Notify(string output)
        {
            Console.WriteLine("WebService Notifies: " + output);
        }
    }
}
