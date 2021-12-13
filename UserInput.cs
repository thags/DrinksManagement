using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinksManagement
{
    public class UserInput
    {
        public static bool CheckUserInputChoice(string userInput, List<List<object>> availableOptions)
        {
            string unFormatUserInput = RipStringOfFormatting(userInput);
            foreach (List<object> list in availableOptions)
            {
                foreach (string option in list)
                {
                    string unFormatOption = RipStringOfFormatting(option);
                    if (unFormatOption == unFormatUserInput || unFormatUserInput == "0")
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool TryGetUserChoice(out string userInput, List<List<object>> availableOptions, int numAllowedAttempts = 5 )
        {
            int totalAttempts = 0;
            bool trueOptionChosen;
            do
            {
                Console.WriteLine("\nInput choice: ");
                Console.WriteLine("0 to exit");
                userInput = Console.ReadLine();
                trueOptionChosen = CheckUserInputChoice(userInput, availableOptions);
                if (trueOptionChosen) { return true; };
                totalAttempts++;
            } while(totalAttempts < numAllowedAttempts && !trueOptionChosen);
            return false;
        }
        private static string RipStringOfFormatting(string s)
        {
            s = s.Replace(" ", "");
            s = s.ToLower();
            return s;
        }
    }
}
