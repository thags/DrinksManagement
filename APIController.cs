using DrinksManagement.Models;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DrinksManagement
{
    class APIController
    {
        private static readonly HttpClient client = new HttpClient();
        private static readonly string APIURL = ConfigurationManager.AppSettings.Get("ApiBaseURL");
        public static async Task<CategoryListModel> GetDrinkCategories()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            string ApiUrl = APIURL + "list.php?c=list";
            var streamTask = client.GetStreamAsync(ApiUrl);


            var options = new JsonSerializerOptions();
            options.Converters.Add(new JsonStringEnumConverter());
            var categorieList = await JsonSerializer.DeserializeAsync<CategoryListModel>(await streamTask, options);
            return categorieList;
        }
        public static async Task<DrinkListModel> GetDrinksByCategory(string categoryName)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            string ApiUrl = APIURL + $"filter.php?c={categoryName}";
            var streamTask = client.GetStreamAsync(ApiUrl);


            var options = new JsonSerializerOptions();
            options.Converters.Add(new JsonStringEnumConverter());
            var categorieList = await JsonSerializer.DeserializeAsync<DrinkListModel>(await streamTask, options);
            return categorieList;
        }
        public static async Task<DrinkModel> GetDrinkInfoByName(string drinkName)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            string ApiUrl = APIURL + $"search.php?s={drinkName}";
            var streamTask = client.GetStreamAsync(ApiUrl);


            var options = new JsonSerializerOptions();
            options.Converters.Add(new JsonStringEnumConverter());
            var drinkList = await JsonSerializer.DeserializeAsync<DrinkListModel>(await streamTask, options);
            var chosenDrink = drinkList.drinks[0];
            return chosenDrink;
        }

    }
}
