using System.Collections.Generic;

namespace DrinksManagement.Models.DTO
{
    public class DrinkInstructionDTO
    {
        public string DrinkName { get; set; }
        public List<InstructionDTO> Instructions { get; set; }
        public List<IngredientDTO> Ingredients { get; set; }
    }
}
