using System;
using System.Collections.Generic;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            UserOutput.PrintWelcomeMessage();

            bool continueCalc = false;
            do
            {
                int mode = UserInput.AskForCalculationMode();
                string answer = "";

                switch (mode)
                {
                    case (int)UserInput.Mode.Numbers:
                        answer = new NumberCalculator().PerformOneCalculation();
                        break;
                    case (int)UserInput.Mode.Dates:
                        answer = new DateCalculator().PerformOneDateCalculation();
                        break;
                }

                UserOutput.PrintAnswer(answer);
                continueCalc = UserInput.ShouldContinue();
            }
            while (continueCalc);

            UserOutput.PrintFarewellMessage();
            Console.ReadLine();
        }
    }
}
