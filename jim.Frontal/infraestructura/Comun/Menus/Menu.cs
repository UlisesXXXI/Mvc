using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jim.Frontal.infraestructura.Comun.Menus
{
    public class Menu
    {
        public Menu()
        {
            Actions = new List<string>(); 
        }
        public string NombreControlador { get; set; }
        public string Area { get; set; }
        public List<String> Actions { get; set; }
    }
}