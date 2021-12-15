using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinksManagement.Models
{
    class UserInputModel
    {
        public string UserChoice { get; set; }
        public bool InputIsValid { get; set; }
        public bool WantsExit { get; set; }
    }
}
