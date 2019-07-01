using jim.Bll.Autentificacion;
using jim.Dal.entities.Autentificacion;
using jim.Frontal.Helpers.Controllers;
using jim.Frontal.ViewModel.Usuarios;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace jim.Frontal.Areas.Administracion.Controllers
{
    public class UsuariosController : BaseController
    {
        private UserService _userService;
        public UsuariosController(UserService userService)
        {
            this._userService = userService;
        }
        // GET: Administracion/Usuarios
        public ActionResult Index(string busqueda = null, int paginaactual = 1, int CantidadPorPagina=10)
        {

            ViewBag.busqueda = busqueda;
            List<ApplicationUser> listado = null; 
            if (!string.IsNullOrEmpty(busqueda)){
                 listado = _userService.Users.Where(x => x.Email.Contains(busqueda) || x.UserName.Contains(busqueda)).ToList();
            }
            else
            {
                listado = _userService.Users.ToList();
            }

            //PagedList.IPagedList paginador = new PagedList.PagedList<ApplicationUser>(listado, paginaactual, CantidadPorPagina);
            var paginado = listado.ToPagedList(paginaactual, CantidadPorPagina);
           
            
            return View(paginado);
        }

        // GET: Administracion/Usuarios/Details/5
        public async Task<ActionResult>  Details(string id)
        {
            ApplicationUser usuario = await _userService.FindByIdAsync(id);
           

            if (usuario == null)
            {
                return HttpNotFound();
            }

            
            UserViewModel usuarioVm = new UserViewModel(usuario);
            return View(usuarioVm);
        }

        // GET: Administracion/Usuarios/Create
        public ActionResult Create(newUserViewModel user)
        {
            if (user == null) user = new newUserViewModel();

            return View(user);
        }

        // POST: Administracion/Usuarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Insert(newUserViewModel user)
        {
            try
            {
                var resultado = await _userService.CreateAsync(new ApplicationUser { Email = user.Email, UserName = user.Email }, user.Password);
                if (resultado.Succeeded)
                {
                    var usuario = await _userService.FindByEmailAsync(user.Email);
                    AddMessage("Usuario Creado correctamente", Helpers.Managers.MessageType.Normal);
                    return RedirectToAction("Details",new { id = usuario.Id });
                }
                foreach (var e in resultado.Errors)
                {
                    AddMessage(e, Helpers.Managers.MessageType.Error);
                }

                
                
            }
            catch
            {
                AddMessage("Hubo un error al crear el usuario", Helpers.Managers.MessageType.Error);
                
            }
            user.Password = "";
            user.RePassword = "";
            return RedirectToAction("Create", user);
        }

        // GET: Administracion/Usuarios/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Administracion/Usuarios/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Administracion/Usuarios/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Administracion/Usuarios/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

            
        }

        [HttpGet]
        public ActionResult ChangeEmail(string id)
        {
            ChangeEmailViewModel vm = new ChangeEmailViewModel();
            vm.Id = id;

            return View(vm);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> ChangeEmail(ChangeEmailViewModel profile)
        {
            var result = await  _userService.SetEmailAsync(profile.Id, profile.Email);
            
            
            return RedirectToAction("Details","Usuarios",new { id = profile.Id });
        }

      

        public ActionResult ChangeEmail(string id, string email)
        {
            return null;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel vm)
        {
            var resultado = await _userService.ChangePasswordAsync(vm.id, vm.CurrentPassword, vm.NewPassword);
            if (resultado.Succeeded)
            {
                AddMessage("Password cambiado correctamente", Helpers.Managers.MessageType.Normal);

                

            }
            else
            {
                AddMessage("Hubo un error al cambiar la contraseña", Helpers.Managers.MessageType.Error);
            }

            return RedirectToAction("Details", new { @id = vm.id});
        }

        public async Task<ActionResult> ChangePassword(string id)
        {
            ChangePasswordViewModel vm = new ChangePasswordViewModel();
            vm.id = id;

            return View(vm);
        }
        public ActionResult ChangeTwoFactorAutentification(string id)
        {
            return null;
        }

       

        
    }
}
