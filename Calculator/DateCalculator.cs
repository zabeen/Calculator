using System;
namespace Calculator
{
    public class DateCalculator
    {
        private Log _log;

        public DateCalculator(Log log)
        {
            _log = log;
        }

        public string PerformOneDateCalculation()
        {
            // Request inputs
            DateTime originalDate = GetDateFromUser();
            int daysToAdd = UserInput.GetInteger("Please enter the number of days to add: ");

            DateTime answer = originalDate.AddDays(daysToAdd);
            String shortDateAnswer = answer.ToShortDateString();

            LogCalculation(originalDate.ToShortDateString(), daysToAdd.ToString(), shortDateAnswer);

            return shortDateAnswer;
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

        private void LogCalculation(string originalDate, string daysToAdd, string answer)
        {
            _log.AppendTextToLogEntry(
                string.Format(
                    "{0}\t{1}\t{2} + {3}days\t{4}\n",
                    DateTime.Now.ToString(),
                    UserInput.Mode.Dates,
                    originalDate,
                    daysToAdd,
                    answer));       
        }
    }
}
