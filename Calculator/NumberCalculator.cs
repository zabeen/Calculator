using System;
using System.Collections.Generic;

namespace Calculator
{
    public class NumberCalculator
    {
        private List<string> _operators = new List<string> { "+", "-", "*", "/" };
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

            List<int> operands = GetListOfOperands(operatorStr);
            CalculateAnswer(operatorStr, operands);

            return _output;
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

        private void CalculateAnswer(string operatorStr, List<int> operands)
        {
            decimal answer = 0;
            for (int i = 0; i < operands.Count; i++)
            {
                // Set answer var to val of first input on first loop
                if (i == 0)
                {
                    answer = operands[i];
                    _output.Operands = operands[i].ToString();
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

                    _output.Operands += string.Format(",{0}", operands[i].ToString());
                }
            }

            _output.Answer = answer.ToString();
            _log.AddToCalculatorOutput(_output);
        }
    }
}
