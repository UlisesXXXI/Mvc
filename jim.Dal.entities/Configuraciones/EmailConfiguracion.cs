using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jim.Dal.entities.Configuraciones
{
    public class EmailConfiguracion
    {
        public int EmailConfiguracionId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Ssl { get; set; }
        public string Host { get; set; }
        public int Puerto { get; set; }

    }
}
