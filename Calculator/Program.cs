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

            bool continueCalc = false;
            do
            {
                int mode = UserInput.AskForCalculationMode();
                string answer = "";

                switch (mode)
                {
                    case (int)UserInput.Mode.Numbers:
                        answer = new NumberCalculator(log).PerformOneCalculation();
                        break;
                    case (int)UserInput.Mode.Dates:
                        answer = new DateCalculator(log).PerformOneDateCalculation();
                        break;
                }

                UserOutput.PrintAnswer(answer);
                continueCalc = UserInput.ShouldContinue();
            }
            while (continueCalc);

            UserOutput.PrintFarewellMessage();
            log.CommitLogEntryToFile();

            Console.ReadLine();
        }
    }
}
