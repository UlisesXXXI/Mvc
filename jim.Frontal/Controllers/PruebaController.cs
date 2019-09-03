using jim.Frontal.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace jim.Frontal.Controllers
{
    public class PruebaController : Controller
    {
        // GET: Prueba
        public ActionResult Index()
        {
            PruebaViewModel vm = new PruebaViewModel();
            vm.Fecha = DateTime.Now;

            return View();
        }

        public ActionResult Validar(PruebaViewModel vm)
        {
            if (ModelState.IsValid)
            {

            }
            return View("Index", vm);
        }
    }
}