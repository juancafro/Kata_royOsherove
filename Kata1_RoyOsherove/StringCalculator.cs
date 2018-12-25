using System;
using System.Collections.Generic;
using System.Text;

namespace Kata1_RoyOsherove
{
    public class StringCalculator
    {
        public int Add(string numbers) {
            try
            {
                if (string.IsNullOrWhiteSpace(numbers))
                {
                    return 0;
                }
                string[] numbersstr = numbers.Split(",");
                if (numbersstr.Length == 1)
                    return int.Parse(numbersstr[0]);
                else
                    return int.Parse(numbersstr[0]) + int.Parse(numbersstr[1]);
            }
            catch (FormatException ex) {
                throw new Exception("some of the chars in "+numbers+" aren't numbers" );
            }
        }
    }
}
