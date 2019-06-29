using jim.Bll.Autentificacion;
using jim.Dal.entities.Autentificacion;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace jim.Frontal.Areas.Administracion.Controllers
{
    public class UsuariosController : Controller
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
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Administracion/Usuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administracion/Usuarios/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
    }
}
