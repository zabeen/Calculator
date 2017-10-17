using System;
using System.Collections.Generic;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintWelcomeMessage();

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

                Console.WriteLine("The answer is {0}.", answer);

                continueCalc = UserInput.ShouldContinue();
            }
            while (continueCalc);

            PrintFarewellMessage();

            // Wait
            Console.ReadLine();
        }

        private static void PrintWelcomeMessage()
        {
            Console.WriteLine("Welcome to the calculator!\n==========================");
        }

        private static void PrintFarewellMessage()
        {
            Console.WriteLine("Goodbye!");
        }

    }
}
