using DrinksManagement.Models;
using System;
using System.Threading.Tasks;

namespace DrinksManagement
{
    class Program
    {
        static async Task Main(string[] args)
        {
            bool exit = false;
            do
            {
                Console.Clear();
                UserInputModel catInputResults = await MenuController.ShowCategoryMenuGetUserInputAsync();
                exit = catInputResults.WantsExit;

                if (catInputResults.InputIsValid)
                {
                    Console.Clear();
                    UserInputModel drinkInputResults = await MenuController.ShowDrinksByCategoryMenuGetUserInputAsync(catInputResults.UserChoice);
                    if (drinkInputResults.InputIsValid)
                    {
                        Console.Clear();
                        await MenuController.ShowDrinkInstructionsToUserAsync(drinkInputResults.UserChoice);
                        Console.WriteLine("Input any key to continue");
                        Console.ReadKey();
                    }
                }

            } while (!exit);


        }
    }
}
