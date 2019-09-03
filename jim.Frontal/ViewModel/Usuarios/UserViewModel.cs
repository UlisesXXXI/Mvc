using jim.Dal.entities.Autentificacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jim.Frontal.ViewModel.Usuarios
{
    public class UserViewModel
    {
        #region constructor
        public UserViewModel()
        {
            DefaultProperties();
        }
        public UserViewModel(ApplicationUser user)
        {
            this.Id = user.Id;
            this.Email = user.Email;
            this.UserName = user.UserName;
            this.EmailConfirmed = user.EmailConfirmed;
            this.PhoneNumber = user.PhoneNumber;
            this.TwoFactorEnabled = user.TwoFactorEnabled;
            this.LockoutEndDateUtc = user.LockoutEndDateUtc;
            this.LockoutEnabled = user.LockoutEnabled;
            this.AccessFailedCount = user.AccessFailedCount;
        }

        
        #endregion

        #region Propiedades publicas
        public string Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        #endregion

        #region Propiedades navegacion

        public ApplicationRole Roles { get; set; }

        #endregion

        #region Propiedades Presentacion

        public List<ApplicationRole> AllRoles { get; set; }

        public List<String> RolesUsuario { get; set; }

        #endregion



        #region Metodos Publicos
        private void DefaultProperties()
        {
            LockoutEnabled = false;
            TwoFactorEnabled = false;
        }
        #endregion




    }
}