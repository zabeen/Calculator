using System;
using System.Collections.Generic;

namespace Calculator
{
    class Program
    {
        static List<string> operators = new List<string> { "+", "-", "*", "/" };

        static void Main(string[] args)
        {
            PrintWelcomeMessage();

            bool continueCalc = false;
            do
            {
                PerformOneCalculation();
                continueCalc = ShouldContinue();
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

        private static void PerformOneCalculation()
        {
            // Request inputs
            string operatorStr = GetOperatorFromUser();
            int noOfOperands = GetIntegerFromUser("How many numbers do you want to " + operatorStr + "? ");
            decimal answer = CalculateAnswer(operatorStr, noOfOperands);

            // write out final answer
            Console.WriteLine("The answer is {0}.", answer);
        }

        private static string GetOperatorFromUser()
        {
            String op = "";
            do
            {
                Console.Write("Please enter the operator: ");
                op = Console.ReadLine();
            }
            while (!operators.Contains(op));

            return op;
        }

        private static int GetIntegerFromUser(string messageStr)
        {
            int submittedInt = 0;
            String input = "";
            do
            {
                Console.Write(messageStr);
                input = Console.ReadLine();
            }
            while (!int.TryParse(input, out submittedInt));

            return submittedInt;
        }

        private static decimal CalculateAnswer (string operatorStr, int noOfOperands)
        {
            decimal answer = 0;
            for (int i = 0; i < noOfOperands; i++)
            {
                // ask for operand
                int operand = GetIntegerFromUser("Please enter number " + (i + 1) + ": ");

                // Set answer var to val of first input on first loop
                if (i == 0)
                {
                    answer = operand;
                }
                else
                {
                    // set calculation by operator
                    switch (operatorStr)
                    {
                        case "+":
                            answer += operand;
                            break;
                        case "-":
                            answer -= operand;
                            break;
                        case "*":
                            answer *= operand;
                            break;
                        case "/":
                            answer /= operand;
                            break;
                        default:
                            break;
                    }
                }
            }

            return answer;
        }

        private static bool ShouldContinue()
        {
            string response = "";
            // keep asking user for response until they type either 'y' or 'n'
            do
            {
                Console.WriteLine("Do you wish to continue? y/n");
                response = Console.ReadLine().ToLower();
            }
            while (response != "y" && response != "n");

            return (response == "y");
        }

        private static void PrintFarewellMessage()
        {
            Console.WriteLine("Goodbye!");
        }
    }
}
