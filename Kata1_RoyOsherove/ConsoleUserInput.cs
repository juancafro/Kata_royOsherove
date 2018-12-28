using System;
using System.Collections.Generic;
using System.Text;

namespace Kata1_RoyOsherove
{
    class ConsoleUserInput : IInput
    {
        public string GetInput()
        {
            return System.Text.RegularExpressions.Regex.Unescape(Console.ReadLine());
        }
    }
}
