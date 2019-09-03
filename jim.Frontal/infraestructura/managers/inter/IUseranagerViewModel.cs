using jim.Frontal.ViewModel.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jim.Frontal.infraestructura.managers.inter
{

    public interface IUserManagerViewModel
    {
        UserViewModel Create();

        UserViewModel Buscar(string id);

       
        
    }
}