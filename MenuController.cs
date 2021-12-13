using DrinksManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinksManagement
{
    class MenuController
    {
        public static MenuModel ConvertCategoryListToMenuModel(CategoryListModel categoryList)
        {
            List<List<object>> convertCategorieList = new List<List<object>>();
            foreach (CategoryItemModel category in categoryList.drinks)
            {
                convertCategorieList.Add(new List<object> { category.strCategory });
            }
            MenuModel categoriesMenu = new MenuModel
            {
                MenuTitle = "Categories",
                MenuItems = convertCategorieList
            };
            return categoriesMenu;
        }
    }
}
