using System;
namespace Calculator
{
    public static class UserOutput
    {
        public static void PrintWelcomeMessage()
        {
            Console.WriteLine("Welcome to the calculator!\n==========================");
        }

        public static void PrintFarewellMessage()
        {
            Console.WriteLine("Goodbye!");
        }

        public static void PrintAnswer(string answer)
        {
            Console.WriteLine("The answer is {0}.", answer);
        }
    }
}
