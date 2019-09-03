using jim.Dal.entities;
using jim.Dal.entities.Autentificacion;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jim.dal
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public  DbSet<Tipo> TIPOS { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Configuration.LazyLoadingEnabled = false;

            Configuration.ProxyCreationEnabled = false;

            Database.Log =Console.WriteLine;

            Database.Log = Consola;
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public void Consola(string mensaje)
        {
            ConsoleColor tempColor = Console.ForegroundColor;
            
            Console.ForegroundColor = ConsoleColor.Red;

            System.Diagnostics.Debug.WriteLine(mensaje);

            Console.ForegroundColor = tempColor;
        }
    }
}
