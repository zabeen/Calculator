﻿using System;
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

        public static int AskForCalculationMode()
        {
            int selectedMode = 0;
            do
            {
                string msg = string.Format(
                    "Which calculator mode do you want?\n{0}) {1}\n{2}) {3}\n",
                    (int)Mode.Numbers, Mode.Numbers, (int)Mode.Dates, Mode.Dates);
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