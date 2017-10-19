using System;
using System.Collections.Generic;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            UserOutput.PrintWelcomeMessage();

            Log log = new Log("CalculatorLog.txt");

            Dictionary<int, ICalculator> calcs = CreateCalculatorDict(ref log);

            do
            {
                int mode = UserInput.AskForCalculationMode();

                try
                {
                    string answer = calcs.GetValueOrDefault(mode).PerformOneCalculation();
                    UserOutput.PrintAnswer(answer);
                }
                catch (ArgumentException ex)
                {
                    UserOutput.PrintError(ex.Message);
                }
            }
            while (UserInput.ShouldContinue());

            UserOutput.PrintFarewellMessage();

            log.CommitOutputToLogFile();

            Console.ReadLine();
        }

        private static Dictionary<int, ICalculator> CreateCalculatorDict(ref Log log)
        {
            return new Dictionary<int, ICalculator>()
            {
                { (int)UserInput.Mode.Numbers, new NumberCalculator(log)},
                { (int)UserInput.Mode.Dates, new DateCalculator(log)}
            };
        }
    }
}
