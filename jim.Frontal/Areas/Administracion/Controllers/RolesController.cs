using jim.dal;
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
    [Authorize(Roles ="Admin")]
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

            return View();
        }
        
        public ActionResult Edit(string id)
        {
            var role = _roleService.FindById(id);
            if (role == null) return HttpNotFound();
            return View(role);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ApplicationRole role)
        {
            if (ModelState.IsValid)
            {
                
                _roleService.Create(role);
                AddMessage("Guardado correctamente", Helpers.Managers.MessageType.Normal);
                return RedirectToAction("Edit", new { id = role.Id });
            }
            
            AddMessage("Error al guardar", Helpers.Managers.MessageType.Error);
     
            return View("Create", role);
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ApplicationRole role)
        {
            if (ModelState.IsValid)
            {
                _roleService.Update(role);
                AddMessage("Guardado correctamente", Helpers.Managers.MessageType.Normal);
                return RedirectToAction("Edit", new { id = role.Id });
            }
            
            AddMessage("Guardado correctamente", Helpers.Managers.MessageType.Error);
            return View( role);
        }

        public JsonResult rolesjson(string buscador)
        {
            var roles = _roleService.Roles.Where(x => x.Name.Contains(buscador)).ToList(); ;
            return Json(roles.Select(m=>new { id=m.Id,value=m.Id, label=m.Name}), JsonRequestBehavior.AllowGet);
        }

        
    }
}