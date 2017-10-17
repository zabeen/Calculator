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
                int mode = AskForCalculationMode();

                switch (mode)
                {
                    case 1:
                        PerformOneCalculation();
                        break;
                    case 2:
                        PerformOneDateCalculation();
                        break;
                }

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

        private static int AskForCalculationMode()
        {
            int mode = 0;
            do
            {
                string msg = "Which calculator mode do you want?" + "\n" + "1) Numbers" + "\n" + "2) Dates" + "\n";
                mode = GetIntegerFromUser(msg);
            }
            while (mode != 1 && mode != 2);

            return mode;
        }

        private static void PerformOneCalculation()
        {
            // Request inputs
            string operatorStr = GetOperatorFromUser();
            List<int> operands = GetListOfOperands(operatorStr);
            decimal answer = CalculateAnswer(operatorStr, operands);

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

        private static List<int> GetListOfOperands(string operatorStr)
        {
            List<int> operands = new List<int>();
            int noOfOperands = GetIntegerFromUser(string.Format("How many numbers do you want to {0}? ", operatorStr));

            for (int i = 0; i < noOfOperands; i++)
            {
                // ask for operand
                operands.Add(GetIntegerFromUser(string.Format("Please enter number {0}: ", i + 1)));
            }

            return operands;
        }

        private static decimal CalculateAnswer(string operatorStr, List<int> operands)
        {
            decimal answer = 0;
            for (int i = 0; i < operands.Count; i++)
            {
                // Set answer var to val of first input on first loop
                if (i == 0)
                {
                    answer = operands[i];
                }
                else
                {
                    // set calculation by operator
                    switch (operatorStr)
                    {
                        case "+":
                            answer += operands[i];
                            break;
                        case "-":
                            answer -= operands[i];
                            break;
                        case "*":
                            answer *= operands[i];
                            break;
                        case "/":
                            answer /= operands[i];
                            break;
                        default:
                            break;
                    }
                }
            }

            return answer;
        }

        private static void PerformOneDateCalculation()
        {
            // Request inputs
            DateTime originalDate = GetDateFromUser();
            int daysToAdd = GetIntegerFromUser("Please enter the number of days to add: ");
            DateTime answer = originalDate.AddDays(daysToAdd);

            // write out final answer
            Console.WriteLine("The answer is {0}.", answer.ToShortDateString());
        }

        private static DateTime GetDateFromUser()
        {
            DateTime submittedDate;
            String input = "";
            do
            {
                Console.Write("Please enter a date: ");
                input = Console.ReadLine();
            }
            while (!DateTime.TryParse(input, out submittedDate));

            return submittedDate;
        }
    }
}
