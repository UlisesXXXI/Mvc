using jim.Dal.entities.Autentificacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jim.Frontal.infraestructura.Comun
{
    public class ContextoAplicacion
    {
        public static ApplicationUser UsuarioActual { get; set; }

    }
}