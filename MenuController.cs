using DrinksManagement.Models;
using DrinksManagement.Models.DTO;
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

        public static DrinkListDTO ConvertDrinkListToNamesMenu(DrinkListModel drinkList)
        {
            var justDrinkNamesList = new List<List<object>> ();
            foreach(DrinkModel drink in drinkList.drinks)
            {
                justDrinkNamesList.Add(new List<object> { drink.strDrink });
            }
            DrinkListDTO drinkListMenu = new DrinkListDTO
            {
                DrinkNameList = justDrinkNamesList
            };

            return drinkListMenu;
        }

        public static DrinkInfoDTO ConvertDrinkModelToDisplay(DrinkModel drink)
        {
            var allIngredientList = new List<List<object>>
            {
                new List<object> {drink.strIngredient1, drink.strMeasure1},
                new List<object> {drink.strIngredient2, drink.strMeasure2},
                new List<object> {drink.strIngredient3, drink.strMeasure3},
                new List<object> {drink.strIngredient4, drink.strMeasure4},
                new List<object> {drink.strIngredient5, drink.strMeasure5},
                new List<object> {drink.strIngredient6, drink.strMeasure6},
                new List<object> {drink.strIngredient7, drink.strMeasure7},
                new List<object> {drink.strIngredient8, drink.strMeasure8},
                new List<object> {drink.strIngredient9, drink.strMeasure9},
                new List<object> {drink.strIngredient10, drink.strMeasure10},
                new List<object> {drink.strIngredient11, drink.strMeasure11},
                new List<object> {drink.strIngredient12, drink.strMeasure12},
                new List<object> {drink.strIngredient13, drink.strMeasure13},
                new List<object> {drink.strIngredient14, drink.strMeasure14},
                new List<object> {drink.strIngredient15, drink.strMeasure15},
            };
            return new DrinkInfoDTO
            {
                DrinkIngredients = allIngredientList,
                DrinkName = drink.strDrink,
                Instructions = drink.strInstructions
            };
        }
    }
}
