using System;
using System.Collections.Generic;
using System.Text;

namespace Kata1_RoyOsherove
{
    public class StringCalculator : IStringCalculator
    {
        public ILogger logger;
        public IWebService webService;
        public StringCalculator(ILogger logger, IWebService webService)
        {
            this.logger = logger;
            this.webService = webService;
        }

        public int Add(string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers))
            {
                return 0;
            }
            int acumulator = 0;
            char[] defaultdelimiters = { ',', '\n' };
            string[] numbersstr;
            if (numbers.StartsWith("//"))
            {
                string[] entryParts = numbers.Split('\n');
                if (entryParts.Length > 1)
                {
                    if (!string.IsNullOrEmpty(entryParts[0]))
                    {
                        string[] delimitier = entryParts[0].TrimStart('/').Split("][");
                        List<string> delimitiersList = new List<string>();
                        foreach (string item in delimitier)
                        {
                            delimitiersList.Add(item.Trim('[', ']'));
                        }
                        numbersstr = entryParts[1].Split(delimitiersList.ToArray(), StringSplitOptions.None);
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
            else
            {
                numbersstr = numbers.Split(defaultdelimiters);
            }
            for (int i = 0; i < numbersstr.Length; i++)
            {
                int number;
                try
                {
                    number = int.Parse(numbersstr[i]);
                }
                catch (FormatException ex)
                {
                    throw new Exception("some of the chars in " + numbers + " aren't numbers");
                }
                if (number < 0)
                    throw new InvalidOperationException("can't operate the array: {" + numbers + "} contains negative numbers");
                if (number < 1000)
                    acumulator += number;
            }
            try
            {
                logger.Write("The result is " + acumulator);
            }
            catch (Exception ex) {
                webService.Notify(ex.Message);
            }
            return acumulator;


        }
    }
}
