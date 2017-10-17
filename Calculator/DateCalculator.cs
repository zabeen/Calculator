using System;
namespace Calculator
{
    public class DateCalculator
    {
        public DateCalculator()
        {
        }

        public string PerformOneDateCalculation()
        {
            // Request inputs
            DateTime originalDate = GetDateFromUser();
            int daysToAdd = UserInput.GetInteger("Please enter the number of days to add: ");
            DateTime answer = originalDate.AddDays(daysToAdd);

            return answer.ToShortDateString();
        }

        private DateTime GetDateFromUser()
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
