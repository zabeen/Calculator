using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the calculator!\n==========================");

            // Request inputs
            Console.Write("Please enter the operator: ");
            String op = Console.ReadLine();

            Console.Write("Please enter the first number: ");
            String firstNo = Console.ReadLine();

            Console.Write("Please enter the second number: ");
            String secondNo = Console.ReadLine();

            // try block to handle exception when non-int input submitted
            try
            {
                int x = int.Parse(firstNo);
                int y = int.Parse(secondNo);
                int answer = 0;
                bool errorFlag = false;

                // set calculation by operator
                switch (op)
                {
                    case "+":
                        answer = x + y;
                        break;
                    case "-":
                        answer = x - y;
                        break;
                    case "*":
                        answer = x * y;
                        break;
                    case "/":
                        answer = x / y;
                        break;
                    default:
                        Console.WriteLine("Error: unexpected operator. Only +, -, * or / accepted.");
                        errorFlag = true;
                        break;
                }

                // only write out answer if no errors encountered
                if(!errorFlag)
                    Console.WriteLine("The answer is: {0}", answer);
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Only integers allowed.");
            }

            // Wait
            Console.ReadLine();

        }
    }
}
