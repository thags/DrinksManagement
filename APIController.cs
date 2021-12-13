using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace DrinksManagement
{
    class APIController
    {
        private static readonly HttpClient client = new HttpClient();
        public static async Task GetDrinkCategories()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var stringTask = client.GetStringAsync("https://www.thecocktaildb.com/api/json/v1/1/list.php?c=list");

            var msg = await stringTask;
            Console.Write(msg);
        }
        

    }
}
