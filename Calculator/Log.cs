using System;
using System.IO;
using System.Text;

namespace Calculator
{
    public class Log
    {
        private string _writePath = "";
        private StringBuilder _logEntry = new StringBuilder();
        private string _logHeaderText = "DateTime\tMode\tCalculation\tAnswer\n";

        public Log(string writePath)
        {
            _writePath = writePath;

            if (File.Exists(_writePath))
                ClearLog();
            else
                CreateLog();
        }

        public void AppendTextToLogEntry(string text)
        {
            _logEntry.Append(text);
        }

        public void CommitLogEntryToFile()
        {
            try
            {
                using (StreamWriter sw = File.AppendText(_writePath))
                {
                    sw.WriteLine(_logEntry);
                }
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
                File.WriteAllText(_writePath, _logHeaderText);
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
                    sw.Write(_logHeaderText);
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
