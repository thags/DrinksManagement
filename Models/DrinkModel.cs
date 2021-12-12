using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinksManagement.Models
{
    //This should be used to create Drink object from the API call to TheCocktailDB
    class DrinkModel
    {
        public string DrinkName { get; set; }
        public int DrinkId { get; set; }
    }
}
