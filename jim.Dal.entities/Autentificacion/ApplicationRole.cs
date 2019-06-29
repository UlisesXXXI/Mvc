using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jim.Dal.entities.Autentificacion
{
    public class ApplicationRole:IdentityRole
    {
        public bool Activo { get; set; }
        #region Constructor
        public ApplicationRole()
        {
            Activo = true;
        }
        public ApplicationRole(string roleName) : base(roleName)
        {
            Activo = true;
        }
        #endregion

    }
}
