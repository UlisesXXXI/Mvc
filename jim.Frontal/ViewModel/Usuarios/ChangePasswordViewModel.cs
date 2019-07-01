using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace jim.Frontal.ViewModel.Usuarios
{
    public class ChangePasswordViewModel
    {
        public string id { get; set; }
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
    }
}