using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinksManagement
{
    class UserInput : IUserInput
    {
        public bool CheckUserInput(string userInput, List<string> availableOptions)
        {
            string unFormatUserInput = RipStringOfFormatting(userInput);
            foreach (string option in availableOptions)
            {
                string unFormatOption = RipStringOfFormatting(option);
                if (unFormatOption == unFormatUserInput)
                {
                    return true;
                }
            }
            return false;
        }

        public bool TryGetUserInputString(out string userInput, int numAllowedAttempts = 5)
        {
            int totalAttempts = 0;
            do
            {
                userInput = Console.ReadLine();
                totalAttempts++;
            } while(totalAttempts <= numAllowedAttempts);

            

            throw new NotImplementedException();
        }
        private string RipStringOfFormatting(string s)
        {
            s = s.Replace(" ", "");
            s = s.ToLower();
            return s;
        }
    }
}
