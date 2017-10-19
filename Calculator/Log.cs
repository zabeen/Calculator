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
        private List<string> _logHeaderText;

        public Log(string writePath)
        {
            _writePath = writePath;
            _logHeaderText = ConstructHeaderText();

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

                foreach (CalculatorOutput entry in _output)
                {
                    lines.Add(ConstructLogEntryString(entry));
                }

                File.AppendAllLines(_writePath, lines);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ConstructErrorMessage("commiting entry to", ex.Message));
            }
        }

        private string ConstructLogEntryString(CalculatorOutput entry)
        {
            return string.Format(
                "{0}\t{1}\t{2}\t{3}\t{4}",
                entry.DateTime,
                entry.Mode,
                entry.Operator,
                entry.Operands,
                entry.Answer);
        }

        private string ConstructErrorMessage(string action, string exception)
        {
            return string.Format("Error when {0} log file, located at {1}.\n{2}", action, _writePath, exception);
        }

        private List<string> ConstructHeaderText()
        {
            List<string> header = new List<string>();

            header.Add(ConstructLogEntryString(new CalculatorOutput() {
                DateTime = "DateTime",
                Mode = "Mode",
                Operator = "Operator",
                Operands = "Operands",
                Answer = "Answer"
            }));

            return header;
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
    }
}
