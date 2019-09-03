using AutoMapper;
using jim.Dal.entities.Autentificacion;
using jim.Frontal.infraestructura.managers.inter;
using jim.Frontal.ViewModel.Usuarios;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jim.Frontal.infraestructura.managers.impl
{
    public class UserManagerViewModel : IUserManagerViewModel
    {
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<ApplicationRole> _roleManager;

        public UserManagerViewModel(UserManager<ApplicationUser> userManager
                                    ,RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;

            _roleManager = roleManager;
        }

        public UserViewModel Buscar(string id)
        {
           ApplicationUser user =  _userManager.FindById(id);


           var vm = Mapper.Map<ApplicationUser, UserViewModel>(user);

           return new UserViewModel();

        }

        public UserViewModel Create()
        {
            UserViewModel vm =  new UserViewModel();
            return vm;
        }
    }
}