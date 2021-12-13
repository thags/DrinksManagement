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
            var categoryList = await APIController.GetDrinkCategories();
            var categoryMenu = MenuController.ConvertCategoryListToMenuModel(categoryList);
            TableVisualisationEngine.ViewMenu(categoryMenu);
            bool inputSuccess = UserInput.TryGetUserChoice(out string userInput, categoryMenu.MenuItems);

            Console.WriteLine(inputSuccess);

            
        }
    }
}
