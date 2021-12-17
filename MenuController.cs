using DrinksManagement.Models;
using DrinksManagement.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DrinksManagement
{
    class MenuController
    {
        public static async Task ShowDrinkInstructionsToUserAsync(string drinkName)
        {
            DrinkModel chosenDrink = await APIController.GetDrinkInfoByName(drinkName);
            DrinkInstructionDTO chosenDrinkInstuctions = ConvertDrinkModelToDisplay(chosenDrink);
            TableVisualisationEngine.ViewMenu(chosenDrinkInstuctions.Ingredients, chosenDrinkInstuctions.DrinkName);
            TableVisualisationEngine.ViewMenu(chosenDrinkInstuctions.Instructions, "Instructions");
        }
        public static async Task<UserInputModel> ShowDrinksByCategoryMenuGetUserInputAsync(string category)
        {
            var drinksList = await APIController.GetDrinksByCategory(category);
            MenuModel drinkListMenu = ConvertDrinkListToNamesMenu(drinksList);
            TableVisualisationEngine.ViewMenu(drinkListMenu.MenuItems, category.ToUpper());
            bool inputIsADrink = UserInput.TryGetUserChoice(out string userInputDrinkName, drinkListMenu.MenuItems);
            return new UserInputModel
            {
                UserChoice = userInputDrinkName,
                InputIsValid = inputIsADrink
            };
        }
        public static async Task<UserInputModel> ShowCategoryMenuGetUserInputAsync()
        {
            bool exit = false;
            var categoryList = await APIController.GetDrinkCategories();
            MenuModel categoryMenu = ConvertCategoryListToMenuModel(categoryList);
            TableVisualisationEngine.ViewMenu(categoryMenu.MenuItems, categoryMenu.MenuTitle);
            bool inputIsACategory = UserInput.TryGetUserChoice(out string userInputCategory, categoryMenu.MenuItems);
            if (userInputCategory == "0")
            {
                exit = true;
            }
            return new UserInputModel
            {
                UserChoice = userInputCategory,
                InputIsValid = inputIsACategory,
                WantsExit = exit,
            };
        }
        public static MenuModel ConvertCategoryListToMenuModel(CategoryListModel categoryList)
        {
            List<MenuItem> convertCategorieList = new List<MenuItem>();
            foreach (CategoryItemModel category in categoryList.drinks)
            {
                convertCategorieList.Add(new MenuItem { Item = category.strCategory });
            }
            MenuModel categoriesMenu = new MenuModel
            {
                MenuTitle = "Categories",
                MenuItems = convertCategorieList
            };
            return categoriesMenu;
        }

        public static MenuModel ConvertDrinkListToNamesMenu(DrinkListModel drinkList)
        {
            var justDrinkNamesList = new List<MenuItem>();
            foreach (DrinkModel drink in drinkList.drinks)
            {
                justDrinkNamesList.Add(new MenuItem { Item = drink.strDrink });
            }
            MenuModel drinkListMenu = new MenuModel
            {
                MenuTitle = "Drink List",
                MenuItems = justDrinkNamesList
            };

            return drinkListMenu;
        }

        public static DrinkInstructionDTO ConvertDrinkModelToDisplay(DrinkModel drink)
        {
            var instructionsList = new List<InstructionDTO>();
            var allIngredientList = new List<IngredientDTO>();
            var allIngredientListBeforeNullCheck = new List<IngredientDTO>
            {
                new IngredientDTO {Ingredient = "Ingredients", Measurement = "Measurements"},
                new IngredientDTO {Ingredient =drink.strIngredient1, Measurement =drink.strMeasure1},
                new IngredientDTO {Ingredient =drink.strIngredient2, Measurement =drink.strMeasure2},
                new IngredientDTO {Ingredient =drink.strIngredient3, Measurement =drink.strMeasure3},
                new IngredientDTO {Ingredient =drink.strIngredient4, Measurement =drink.strMeasure4},
                new IngredientDTO {Ingredient =drink.strIngredient5, Measurement =drink.strMeasure5},
                new IngredientDTO {Ingredient =drink.strIngredient6, Measurement =drink.strMeasure6},
                new IngredientDTO {Ingredient =drink.strIngredient7, Measurement =drink.strMeasure7},
                new IngredientDTO {Ingredient =drink.strIngredient8, Measurement =drink.strMeasure8},
                new IngredientDTO {Ingredient =drink.strIngredient9, Measurement =drink.strMeasure9},
                new IngredientDTO {Ingredient =drink.strIngredient10, Measurement =drink.strMeasure10},
                new IngredientDTO {Ingredient =drink.strIngredient11, Measurement =drink.strMeasure11},
                new IngredientDTO {Ingredient =drink.strIngredient12, Measurement =drink.strMeasure12},
                new IngredientDTO {Ingredient =drink.strIngredient13, Measurement =drink.strMeasure13},
                new IngredientDTO {Ingredient =drink.strIngredient14, Measurement =drink.strMeasure14},
                new IngredientDTO {Ingredient =drink.strIngredient15, Measurement =drink.strMeasure15},
            };

            foreach (IngredientDTO item in allIngredientListBeforeNullCheck)
            {
                if (item.Ingredient != null && item.Measurement != null)
                {
                    allIngredientList.Add(item);
                }
            }

            foreach (string instruction in drink.strInstructions.Split(". "))
            {
                if (instruction.Length > 0)
                {
                    string instructionToAdd = $"{instruction}.";
                    instructionsList.Add(new InstructionDTO { Instruction = instructionToAdd });
                }

            }
            return new DrinkInstructionDTO
            {
                Ingredients = allIngredientList,
                DrinkName = drink.strDrink,
                Instructions = instructionsList
            };
        }
    }
}
