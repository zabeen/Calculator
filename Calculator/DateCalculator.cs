using System;
namespace Calculator
{
    public class DateCalculator
    {
        private Log _log;
        private CalculatorOutput _output;

        public DateCalculator(Log log)
        {
            _log = log;

            _output = new CalculatorOutput(){
                    DateTime = DateTime.Now.ToString(),
                    Mode = "Dates"
                };
        }

        public CalculatorOutput PerformOneDateCalculation()
        {
            // Request inputs
            DateTime originalDate = GetDateFromUser();
            int daysToAdd = UserInput.GetInteger("Please enter the number of days to add: ");

            DateTime answer = originalDate.AddDays(daysToAdd);
            String shortDateAnswer = answer.ToShortDateString();

            LogCalculation(originalDate.ToShortDateString(), daysToAdd.ToString(), shortDateAnswer);

            return _output;
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
            _output.Operator = "+";
            _output.Operands = string.Format("{0}, {1}days", originalDate, daysToAdd);
            _output.Answer = answer;

            _log.AddToCalculatorOutput(_output);
        }
    }
}
