﻿using jim.Bll.Autentificacion;
using jim.Dal.entities.Autentificacion;
using jim.Frontal.Helpers.Controllers;
using jim.Frontal.ViewModel.Usuarios;
using Microsoft.AspNet.Identity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.ApplicationServices;
using System.Web.Mvc;


namespace jim.Frontal.Areas.Administracion.Controllers
{
    [Authorize(Roles ="Admin")]
    public class UsuariosController : BaseController
    {
        private UserService _userService;
        private RoleManager<ApplicationRole>  _roleService;

        
        public UsuariosController(UserService userService,
                                  RoleManager<ApplicationRole>  rolesService  )
        {
            this._roleService = rolesService;
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
            usuarioVm.AllRoles = _roleService.Roles.ToList();
            usuarioVm.RolesUsuario = _userService.GetRoles(usuario.Id).ToList();
            return View(usuarioVm);
        }

        // GET: Administracion/Usuarios/Create
        public ActionResult Create()
        {
            var vm = new newUserViewModel();
            var roles = _roleService.Roles;
            vm.ListaDeRoles = new List<RolesDeUsuarioViewModel>();
            foreach (var rol in roles)
            {
                vm.ListaDeRoles.Add(new RolesDeUsuarioViewModel() { Checked = false, NombreRol = rol.Name });
            }

            return View(vm);
        }

        // POST: Administracion/Usuarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(newUserViewModel user)
        {

            if (ModelState.IsValid)
            {

                if(user.UsuariosChequeados != null && user.UsuariosChequeados.Count > 0)
                {

                    try
                    {
                        var resultado = await _userService.CreateAsync(new ApplicationUser { Email = user.Email, UserName = user.UserName }, user.Password);
                        if (resultado.Succeeded)
                        {
                            var usuario = await _userService.FindByEmailAsync(user.Email);
                            _userService.AddToRoles(usuario.Id, user.UsuariosChequeados.ToArray());
                            AddMessage("Usuario Creado correctamente", Helpers.Managers.MessageType.Normal);
                            return RedirectToAction("Details", new { id = usuario.Id });
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
                }
                else
                {
                    AddMessage("Debe seleccionar un role", Helpers.Managers.MessageType.Error);
                }


            }
            
            user.Password = "";
            user.RePassword = "";
            var roles = _roleService.Roles;
            user.ListaDeRoles = new List<RolesDeUsuarioViewModel>();
            foreach (var rol in roles)
            {
                user.ListaDeRoles.Add(new RolesDeUsuarioViewModel() { Checked = false, NombreRol = rol.Name });
            }
            return View("Create", user);
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
