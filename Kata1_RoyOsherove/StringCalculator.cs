using System;
using System.Collections.Generic;
using System.Text;

namespace Kata1_RoyOsherove
{
    public class StringCalculator
    {
        public int Add(string numbers) {
            if (string.IsNullOrWhiteSpace(numbers))
            {
                return 0;
            }
            try
            {
                int acumulator = 0;
                string[] numbersstr = numbers.Split(',',StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < numbersstr.Length; i++) {
                    acumulator += int.Parse(numbersstr[i]);
                }
                return acumulator;
            }
            catch (FormatException ex) {
                throw new Exception("some of the chars in "+numbers+" aren't numbers" );
            }
        }
    }
}
