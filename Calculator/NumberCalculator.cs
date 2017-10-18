using System;
using System.Collections.Generic;

namespace Calculator
{
    public class NumberCalculator
    {
        private List<string> _operators = new List<string> { "+", "-", "*", "/" };
        private Log _log;

        public NumberCalculator(Log log)
        {
            _log = log;
        }

        public string PerformOneCalculation()
        {
            // Request inputs
            string operatorStr = GetOperatorFromUser();
            List<int> operands = GetListOfOperands(operatorStr);
            decimal answer = CalculateAnswer(operatorStr, operands);

            return answer.ToString();
        }

        private string GetOperatorFromUser()
        {
            String op = "";
            do
            {
                Console.Write("Please enter the operator: ");
                op = Console.ReadLine();
            }
            while (!_operators.Contains(op));

            return op;
        }

        private List<int> GetListOfOperands(string operatorStr)
        {
            List<int> operands = new List<int>();
            int noOfOperands = UserInput.GetInteger(string.Format("How many numbers do you want to {0}? ", operatorStr));

            for (int i = 0; i < noOfOperands; i++)
            {
                // ask for operand
                operands.Add(UserInput.GetInteger(string.Format("Please enter number {0}: ", i + 1)));
            }

            return operands;
        }

        private decimal CalculateAnswer(string operatorStr, List<int> operands)
        {
            decimal answer = 0;
            for (int i = 0; i < operands.Count; i++)
            {
                // Set answer var to val of first input on first loop
                if (i == 0)
                {
                    answer = operands[i];
                    _log.AppendTextToLogEntry(
                        string.Format("{0}\t{1}\t{2}", DateTime.Now.ToString(), UserInput.Mode.Numbers, operands[i].ToString()));
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

                    _log.AppendTextToLogEntry(string.Format("{0}{1}", operatorStr, operands[i].ToString()));
                }
            }

            _log.AppendTextToLogEntry(string.Format("\t{0}\n", answer));

            return answer;
        }
    }
}
