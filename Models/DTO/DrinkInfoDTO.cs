using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinksManagement.Models.DTO
{
    class DrinkInfoDTO
    {
        public string DrinkName { get; set; }
        public List<List<object>> Instructions { get; set; }
        public List<List<object>> DrinkIngredients { get; set; }
    }
}
