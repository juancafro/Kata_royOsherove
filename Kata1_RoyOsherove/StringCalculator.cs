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
                char[] defaultdelimiters = { ',', '\n' };
                string[] numbersstr;  
                if (numbers.StartsWith("//")) {
                    string[] entryParts = numbers.Split('\n');
                    if (entryParts.Length > 1)
                    {
                        if (!string.IsNullOrEmpty(entryParts[0]))
                        {
                            numbersstr = entryParts[1].Split(entryParts[0].TrimStart('/'));
                        }
                        else
                        {
                            numbersstr = entryParts[1].Split(defaultdelimiters);
                        }
                    }
                    else
                    {
                        numbersstr = numbers.Split(defaultdelimiters);
                    }
                }
                else {
                    numbersstr = numbers.Split(defaultdelimiters);
                }
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
