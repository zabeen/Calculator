using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Calculator
{
    public class Log
    {
        private List<CalculatorOutput> _output = new List<CalculatorOutput>();
        private string _writePath = "";
        private string[] _logHeaderText = { "DateTime\tMode\tOperator\tOperands\tAnswer" };

        public Log(string writePath)
        {
            _writePath = writePath;

            if (File.Exists(_writePath))
                ClearLog();
            else
                CreateLog();
        }

        public void AddToCalculatorOutput(CalculatorOutput output)
        {
            _output.Add(output);
        }

        public void CommitOutputToLogFile()
        {
            try
            {
                List<string> lines = new List<string>();

                foreach (CalculatorOutput line in _output)
                {
                    lines.Add(
                        string.Format("{0}\t{1}\t{2}\t{3}\t{4}",
                                      line.DateTime,
                                      line.Mode,
                                      line.Operator,
                                      line.Operands,
                                      line.Answer));
                }

                File.AppendAllLines(_writePath, lines);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ConstructErrorMessage("commiting entry to", ex.Message));
            }
        }

        private void ClearLog()
        {
            try
            {
                File.WriteAllLines(_writePath, _logHeaderText);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ConstructErrorMessage("clearing", ex.Message));
            }
        }

        private void CreateLog()
        {
            try
            {
                using (StreamWriter sw = File.CreateText(_writePath))
                {
                    sw.WriteLine(_logHeaderText[0]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ConstructErrorMessage("creating", ex.Message));
            }
        }

        private string ConstructErrorMessage(string action, string exception)
        {
            return string.Format("Error when {0} log file, located at {1}.\n{2}", action, _writePath, exception);
        }
    }
}
