using System;
using System.Collections.Generic;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the calculator!\n==========================");

            // Request inputs - handle undesired values
            Console.Write("Please enter the operator: ");
            String op = Console.ReadLine();

            if (!new List<string> { "+", "-", "*", "/" }.Contains(op))
            {
                Console.WriteLine("Error: unexpected operator. Only +, -, * or / accepted.");
                return;
            }

            Console.Write("How many numbers do you want to {0}? ", op);
            String noRequested = Console.ReadLine();
            int n = 0;

            if (!CheckStrIsInt(noRequested, out n))
                return;
            
            // ask for operand and apply to answer
            bool errorFlag = false;
            int answer = 0;
            for (int i = 0; i < n; i++)
            {
                Console.Write("Please enter number {0}: ", i);
                String operandStr = Console.ReadLine();
                int operand = 0;

                // only perform calculation if submitted number is an int
                if (CheckStrIsInt(operandStr, out operand))
                {
                    // Set answer var to val of first input on first loop
                    if (i == 0)
                    {
                        answer = operand;
                    }
                    else
                    {
                        // set calculation by operator
                        switch (op)
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
                else
                {
                    errorFlag = true;
                    break;
                }
            }

            // if no errors encountered, write out final answer
            if (!errorFlag)
                Console.WriteLine("The answer is {0}: ", answer);

            // Wait
            Console.ReadLine();

        }

        private static bool CheckStrIsInt(string nStr, out int n)
        {
            bool isInt = false;
            n = 0;

            try
            {
                n = int.Parse(nStr);
                isInt = true;
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: {0} is not an integer.", nStr);
            }

            return isInt;
        }
    }
}
