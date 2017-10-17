using System;
using System.Collections.Generic;

namespace Calculator
{
    public class NumberCalculator
    {
        private List<string> operators = new List<string> { "+", "-", "*", "/" };

        public NumberCalculator()
        {
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
            while (!operators.Contains(op));

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
                }
            }

            return answer;
        }
    }
}
