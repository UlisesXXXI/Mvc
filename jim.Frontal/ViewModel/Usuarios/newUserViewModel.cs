using jim.Dal.entities.Autentificacion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace jim.Frontal.ViewModel.Usuarios
{
    public class newUserViewModel
    {

        public newUserViewModel()
        {
            UsuariosChequeados = new List<string>();
        }
        public string id { get; set; }

        [Required]
        
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="no coinciden los passwords")]
        public string RePassword { get; set; }

        public List<RolesDeUsuarioViewModel> ListaDeRoles{ get; set; }

        public List<string> UsuariosChequeados { get; set; }

    }
}