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
                CalculatorOutput output = new CalculatorOutput();

                switch (mode)
                {
                    case (int)UserInput.Mode.Numbers:
                        output = new NumberCalculator(log).PerformOneCalculation();
                        break;
                    case (int)UserInput.Mode.Dates:
                        output = new DateCalculator(log).PerformOneDateCalculation();
                        break;
                }

                UserOutput.PrintAnswer(output.Answer);
                continueCalc = UserInput.ShouldContinue();
            }
            while (continueCalc);

            UserOutput.PrintFarewellMessage();
            log.CommitOutputToLogFile();

            Console.ReadLine();
        }
    }
}
