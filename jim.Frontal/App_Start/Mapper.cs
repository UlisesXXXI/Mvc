using AutoMapper;
using jim.Dal.entities.Autentificacion;
using jim.Frontal.ViewModel.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jim.Frontal.App_Start
{
    public class AutoMapperConfig
    {
        public static void Config()
        {
            Mapper.Initialize( cfg => cfg.CreateMap<ApplicationUser, UserViewModel>());
        }

    }
}