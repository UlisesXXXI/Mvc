using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace jim.Frontal.infraestructura.Comun.Menus
{
    public class Controlador
    {
        private static UrlHelper _urlHelper = new UrlHelper();

        public Controlador()
        {
            
        }

        public string Control { get; set; }

        public string Area { get; set; }

        public string Accion { get; set; }

        public string Url { get {
                return _urlHelper.Action(Accion, Control, new { area = Area }); } }
    }
}