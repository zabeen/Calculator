using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator
{
    public class NumberCalculator
    {
        private Log _log;
        private CalculatorOutput _output;

        public NumberCalculator(Log log)
        {
            _log = log;

            _output = new CalculatorOutput(){
                DateTime = DateTime.Now.ToString(),
                Mode = "Numbers"
                };
        }

        public CalculatorOutput PerformOneCalculation()
        {
            // Request inputs
            string operatorStr = GetOperatorFromUser();
            _output.Operator = operatorStr;

            List<int?> operands = GetListOfOperands(operatorStr);
            CalculateAnswer(operatorStr, operands);

            return _output;
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

        private void CalculateAnswer(string operatorStr, List<int?> operands)
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

            LogCalculation(numbers, answer);
        }

        private void LogCalculation(List<int> operands, decimal answer)
        {
            _output.Operands = string.Join(",", operands.Select(o => o.ToString()).ToList());
            _output.Answer = answer.ToString();
            _log.AddToCalculatorOutput(_output);
        }
    }
}
