using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinksManagement.Models
{
    class MenuModel
    {
        public string MenuTitle { get; set; }
        public List<List<object>> MenuItems {get; set;}
    }
}
