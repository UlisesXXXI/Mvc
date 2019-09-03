using jim.Frontal.infraestructura.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace jim.Frontal.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index(AppError appError)
        {
            return PartialView(appError);
        }
    }
}