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
                bool inputIsACategory = UserInput.TryGetUserChoice(out string userInputCategory, categoryMenu.MenuItems);
                if (userInputCategory == "0")
                {
                    exit = true;
                    break;
                }

                if (inputIsACategory)
                {
                    var drinksList = await APIController.GetDrinksByCategory(userInputCategory);
                    var drinkListDto = MenuController.ConvertDrinkListToNamesMenu(drinksList);
                    TableVisualisationEngine.ViewDrinksList(drinkListDto, userInputCategory.ToUpper());
                    bool inputIsADrink = UserInput.TryGetUserChoice(out string userInputDrinkName, drinkListDto.DrinkNameList);
                    Console.WriteLine(inputIsADrink);
                    Console.WriteLine($"User Chose {userInputDrinkName}");
                    var chosenDrink = await APIController.GetDrinkInfoByName(userInputDrinkName);
                    var chosenDrinkDTO = MenuController.ConvertDrinkModelToDisplay(chosenDrink);
                    TableVisualisationEngine.ViewDrinkInfo(chosenDrinkDTO);
                    Console.WriteLine("Input any key to continue");
                    Console.ReadKey();

                }
            } while (!exit);


        }
    }
}
