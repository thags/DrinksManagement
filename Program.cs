using System;
using System.Collections.Generic;
using DrinksManagement.Models;

namespace DrinksManagement
{
    class Program
    {
        static void Main(string[] args)
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
        }
    }
}
