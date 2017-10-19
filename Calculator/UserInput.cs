using System;
using System.Collections.Generic;

namespace Calculator
{
    public static class UserInput
    {
        public enum Mode
        {
            Numbers = 1,
            Dates = 2
        }

        public static int GetInteger(string messageStr)
        {
            int submittedInt = 0;
            String input = "";
            do
            {
                Console.Write(messageStr);
                input = Console.ReadLine();
            }
            while (!int.TryParse(input, out submittedInt));

            return submittedInt;
        }

        public static int? GetNullableInteger(string messageStr)
        {
            int? submittedInt = null;
            int parsedInt = 0;
            String input = "";
            do
            {
                Console.Write(messageStr);
                input = Console.ReadLine();
            }
            while (input != "" && !int.TryParse(input, out parsedInt));

            submittedInt = (input == "") ? null : (int?)parsedInt;

            return submittedInt;
        }

        public static int AskForCalculationMode()
        {
            int selectedMode = 0;
            do
            {
                string msg = $"Which calculator mode do you want?\n{(int)Mode.Numbers}) {Mode.Numbers}\n{(int)Mode.Dates}) {Mode.Dates}\n";
                selectedMode = UserInput.GetInteger(msg);
            }
            while (selectedMode != (int)Mode.Numbers && selectedMode != (int)Mode.Dates);

            return selectedMode;
        }

        public static bool ShouldContinue()
        {
            string response = "";
            // keep asking user for response until they type either 'y' or 'n'
            do
            {
                Console.WriteLine("Do you wish to continue? y/n");
                response = Console.ReadLine().ToLower();
            }
            while (response != "y" && response != "n");

            return (response == "y");
        }
    }
}
