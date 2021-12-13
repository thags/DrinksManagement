using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using DrinksManagement.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DrinksManagement
{
    class APIController
    {
        private static readonly HttpClient client = new HttpClient();
        public static async Task<CategoryListModel> GetDrinkCategories()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            var streamTask = client.GetStreamAsync("https://www.thecocktaildb.com/api/json/v1/1/list.php?c=list");


            var options = new JsonSerializerOptions();
            options.Converters.Add(new JsonStringEnumConverter());
            var categorieList = await JsonSerializer.DeserializeAsync<CategoryListModel>(await streamTask, options);
            return categorieList;
        }

    }
}
