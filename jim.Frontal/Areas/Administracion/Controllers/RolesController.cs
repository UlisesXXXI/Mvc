using jim.Dal.entities.Autentificacion;
using jim.Frontal.Helpers.Controllers;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace jim.Frontal.Areas.Administracion.Controllers
{
    public class RolesController :BaseController
    {
        private RoleManager<ApplicationRole> _roleService;

        #region Contructor
        public RolesController(RoleManager<ApplicationRole> roleService)
        {
            _roleService = roleService;
        }
        #endregion





        // GET: Administracion/Roles
        public ActionResult Index(string busqueda = null, int paginaActual = 1, int totalPaginas=10)
        {
            List<ApplicationRole> roles = null;

            if (String.IsNullOrEmpty(busqueda))
            {
                roles = _roleService.Roles.ToList();
            }
            else
            {
                roles = _roleService.Roles.Where(x => x.Name.Contains(busqueda)).ToList();
            }

            ViewBag.busqueda = busqueda;

            PagedList.PagedList<ApplicationRole> rolesPaginado = new PagedList.PagedList<ApplicationRole>(roles, paginaActual, totalPaginas);

            return View(rolesPaginado);
        }

        public ActionResult Create()
        {

            return PartialView();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ApplicationRole role)
        {
            if (ModelState.IsValid)
            {
                
                _roleService.Create(role);
                RedirectToAction("Edit", "Roles", role);
            }
            return View(role);
        }


    }
}