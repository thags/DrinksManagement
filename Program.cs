using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DrinksManagement.Models;

namespace DrinksManagement
{
    class Program
    {
        static async Task Main(string[] args)
        {
            bool exit = false;
            do
            {
                UserInputModel catInputResults = await MenuController.ShowCategoryMenuGetUserInputAsync();
                exit = catInputResults.WantsExit;

                if (catInputResults.InputIsValid)
                {
                    UserInputModel drinkInputResults = await MenuController.ShowDrinksByCategoryMenuGetUserInputAsync(catInputResults.UserChoice);
                    if (drinkInputResults.InputIsValid)
                    {
                        await MenuController.ShowDrinkInstructionsToUserAsync(drinkInputResults.UserChoice);
                        Console.WriteLine("Input any key to continue");
                        Console.ReadKey();
                    }
                }

            } while (!exit);


        }
    }
}
