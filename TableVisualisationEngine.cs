using System;
using System.Collections.Generic;
using ConsoleTableExt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrinksManagement.Models;
using DrinksManagement.Models.DTO;

namespace DrinksManagement
{
    class TableVisualisationEngine
    {
        public static void ViewMenu(MenuModel MenuToView)
        {
            var tableData = MenuToView.MenuItems;
            string title = MenuToView.MenuTitle;

            if (tableData.Count == 0)
            {
                Console.WriteLine("Currently empty!");
            }
            else
            {
                ConsoleTableBuilder
               .From(tableData)
               .WithTitle(title)
               .WithFormat(ConsoleTableBuilderFormat.Alternative)
               .ExportAndWriteLine(TableAligntment.Center);
            }
            Console.Write("\n");
        }

        public static void ViewDrinksList(DrinkListDTO drinkList, string categoryName)
        {
            var tableData = drinkList.DrinkNameList;

            if (tableData.Count == 0)
            {
                Console.WriteLine("Currently empty!");
            }
            else
            {
                ConsoleTableBuilder
               .From(tableData)
               .WithTitle(categoryName)
               .WithFormat(ConsoleTableBuilderFormat.Alternative)
               .ExportAndWriteLine(TableAligntment.Center);
            }
            Console.Write("\n");
        }
    }
}
