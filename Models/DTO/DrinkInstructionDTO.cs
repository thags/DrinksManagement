using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinksManagement.Models.DTO
{
    public class DrinkInstructionDTO
    {
        public string DrinkName { get; set; }
        public List<InstructionDTO> Instructions { get; set; }
        public List<IngredientDTO> Ingredients { get; set; }
    }
}
