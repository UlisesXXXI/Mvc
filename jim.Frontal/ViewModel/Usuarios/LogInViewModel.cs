using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace jim.Frontal.ViewModel.Usuarios
{
    public class LogInViewModel
    {
        public LogInViewModel()
        {

        }

        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool Recordar { get; set; }
    }
}