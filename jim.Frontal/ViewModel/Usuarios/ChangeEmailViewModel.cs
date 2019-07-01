using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace jim.Frontal.ViewModel.Usuarios
{
    public class ChangeEmailViewModel
    {
        public string Id { get; set; }
        [DataType(DataType.EmailAddress,ErrorMessage ="introduzca un email valido")]
        public string Email { get; set; }
    }
}