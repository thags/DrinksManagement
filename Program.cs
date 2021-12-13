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
                var categoryList = await APIController.GetDrinkCategories();
                var categoryMenu = MenuController.ConvertCategoryListToMenuModel(categoryList);
                TableVisualisationEngine.ViewMenu(categoryMenu);
                bool inputSuccess = UserInput.TryGetUserChoice(out string userInput, categoryMenu.MenuItems);
                if (userInput == "0")
                {
                    exit = true;
                    break;
                }

                if (inputSuccess)
                {
                    var drinksList = await APIController.GetDrinksByCategory(userInput);
                    var drinkListDto = MenuController.ConvertDrinkListToNamesMenu(drinksList);
                    TableVisualisationEngine.ViewDrinksList(drinkListDto, userInput);
                    Console.WriteLine("Press any key to continue");
                    Console.ReadLine();
                }
            } while (!exit);


        }
    }
}
