using jim.Dal.entities.Autentificacion;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace jim.Bll.Autentificacion
{
    public class SignInService : SignInManager<ApplicationUser, string>
    {
        public SignInService(UserService userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public void SignIn()
        {
            
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
        {
            return user.GenerateUserIdentityAsync((UserService)UserManager);
        }

        public static SignInService Create(IdentityFactoryOptions<SignInService> options, IOwinContext context)
        {
            return new SignInService(context.GetUserManager<UserService>(), context.Authentication);
        }
    }
}
