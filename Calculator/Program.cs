using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the calculator!");

            // prompt user to provide two numbers
            Console.WriteLine("1st Number:");
            string firstNo = Console.ReadLine();

            Console.WriteLine("2nd Number:");
            string secondNo = Console.ReadLine();

            // Convert numbers to ints - catch error if non-int submitted
            int x;
            int y;

            try
            {
                x = int.Parse(firstNo);
                y = int.Parse(secondNo);

                // multiple the two numbers and write the product
                Console.WriteLine("Result: {0}", x * y);
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
