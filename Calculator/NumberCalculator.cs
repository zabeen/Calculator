using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator
{
    public class NumberCalculator : ICalculator
    {
        private Log _log;

        public NumberCalculator(Log log)
        {
            _log = log;
        }

        public string PerformOneCalculation()
        {
            // Request inputs
            string operatorStr = GetOperatorFromUser();
            List<int?> operands = GetListOfOperands(operatorStr);

            return CalculateAnswer(operatorStr, operands);
        }

        private string GetOperatorFromUser()
        {
            String op = "";

            Console.Write("Please enter the operator: ");
            op = Console.ReadLine();

            return op;
        }

        private List<int?> GetListOfOperands(string operatorStr)
        {
            List<int?> operands = new List<int?>();
            int counter = 0;
            int? currentInt = null;

            do
            {
                counter++;
                currentInt = UserInput.GetNullableInteger(string.Format("Please enter number {0}: ", counter));
                if (currentInt != null)
                    operands.Add(currentInt);
            }
            while (currentInt != null);

            return operands;
        }

        private string CalculateAnswer(string operatorStr, List<int?> operands)
        {
            List<int> numbers = operands.Select(o => o.Value).ToList();

            decimal answer = 0;
            switch (operatorStr)
            {
                case "+":
                    answer = numbers.Sum();
                    break;
                case "-":
                    answer = numbers.Aggregate((a, b) => a - b);
                    break;
                case "*":
                    answer = numbers.Aggregate((a, b) => a * b);
                    break;
                case "/":
                    answer = numbers.Aggregate((a, b) => a / b);
                    break;
                default:
                    throw new ArgumentException(string.Format("\"{0}\" is an unsupported operator.", operatorStr));
            }

            LogCalculation(operatorStr, numbers, answer);

            return answer.ToString();
        }

        private void LogCalculation(string operatorStr, List<int> operands, decimal answer)
        {
            _log.AddToCalculatorOutput(
                new CalculatorOutput()
            {
                DateTime = DateTime.Now.ToString(),
                Mode = "Numbers",
                Operator = operatorStr,
                Operands = string.Join(",", operands.Select(o => o.ToString()).ToList()),
                Answer = answer.ToString()
            });
        }
    }
}
