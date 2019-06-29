using Autofac;
using Autofac.Integration.Mvc;
using jim.Bll.Autentificacion;
using jim.dal;
using jim.Dal.entities.Autentificacion;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.ApplicationServices;
using System.Web.Mvc;

namespace jim.Frontal.App_Start
{
    public class DependenciesConfig
    {
        public static void Config(IAppBuilder app)
        {
            var builder = new ContainerBuilder();

            // Usually you're only interested in exposing the type
            // via its interface:

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

           


            #region Autentificacion
            builder.RegisterType<ApplicationDbContext>().As<IdentityDbContext<ApplicationUser>>().InstancePerRequest();
            builder.RegisterType<ApplicationDbContext>().As<DbContext>().InstancePerRequest();
            builder.RegisterType<UserStore<ApplicationUser>>().As<IUserStore<ApplicationUser>>();
            builder.RegisterType<RoleStore<ApplicationRole>>().As<IRoleStore<ApplicationRole, string>>();
           
            builder.RegisterType<jim.Bll.Autentificacion.RoleService>().As<RoleManager<ApplicationRole>>().InstancePerRequest();

            builder.RegisterType<jim.Bll.Autentificacion.UserService>().As<UserManager<ApplicationUser>>().InstancePerRequest();

            builder.RegisterType<jim.Bll.Autentificacion.UserService>().AsSelf().InstancePerRequest();

            builder.Register(c => HttpContext.Current.GetOwinContext().Authentication).As<IAuthenticationManager>();
            builder.Register(c => new IdentityFactoryOptions<UserService>
            {
                DataProtectionProvider = new Microsoft.Owin.Security.DataProtection.DpapiDataProtectionProvider("Application​")
            });

            builder.RegisterType<SignInService>().AsSelf().InstancePerRequest();

            #endregion




            var container = builder.Build();


           
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            app.UseAutofacMiddleware(container);
            app.UseAutofacMvc();

        }

        private static int IdentityDbContext<T>()
        {
            throw new NotImplementedException();
        }
    }
}