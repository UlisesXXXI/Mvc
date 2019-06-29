using jim.dal;
using jim.Dal.entities.Autentificacion;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jim.Bll.Autentificacion
{
    public class RoleService:RoleManager<ApplicationRole>
    {
        public RoleService(IRoleStore<ApplicationRole,string> roleStore):base(roleStore)
        {

        }

        public static RoleService Create(IdentityFactoryOptions<RoleService> options, IOwinContext context)
        {
            return new RoleService(new RoleStore<ApplicationRole>(context.Get<ApplicationDbContext>()));
            
        }
    }
}
