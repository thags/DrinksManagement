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
            List<List<object>> categorieList = new List<List<object>>
            {
                new List<object>{"Alcoholic"},
                new List<object>{"Non-Alcoholic"},
                new List<object>{"Soda"},
            };
            MenuModel categoriesMenu = new MenuModel
            {
                MenuTitle = "Categories",
                MenuItems = categorieList
            };
            TableVisualisationEngine.ViewMenu(categoriesMenu);
            bool inputSuccess = UserInput.TryGetUserChoice(out string userInput, categorieList);

            Console.WriteLine(inputSuccess);

            await APIController.GetDrinkCategories();
        }
    }
}
