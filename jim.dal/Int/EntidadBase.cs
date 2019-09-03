using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jim.dal.Int
{
    public abstract class EntidadBase
    {
        public int Id { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime FechaModificacion { get; set; }

        public string UsuarioCreacion { get; set; }

        public String UsuarioModificacion { get; set; }
    }
}
