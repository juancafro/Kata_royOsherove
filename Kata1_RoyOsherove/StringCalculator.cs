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
                            string delimitier = entryParts[0].TrimStart('/');
                            delimitier = delimitier.Trim('[', ']');
                            numbersstr = entryParts[1].Split(delimitier);
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
                    int number = int.Parse(numbersstr[i]);
                    if (number < 0) 
                        throw new InvalidOperationException("can't operate the array: {" + numbers + "} contains negative numbers");
                    if (number < 1000) 
                         acumulator += number;
                }
                return acumulator;
            }
            catch (FormatException ex) {
                throw new Exception("some of the chars in "+numbers+" aren't numbers" );
            }
        }
    }
}
