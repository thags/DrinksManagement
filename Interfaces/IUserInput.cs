using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinksManagement
{
    public interface IUserInput
    {
        bool TryGetUserInputString(out string userInput, int numAllowedAttempts);
        bool CheckUserInput(string userInput, List<string> availableOptions);

    }
}
