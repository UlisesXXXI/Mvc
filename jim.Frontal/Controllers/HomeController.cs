using jim.Bll.Autentificacion;
using jim.Dal.entities.Autentificacion;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace jim.Frontal.Controllers
{
    public class HomeController : Controller
    {
        private RoleManager<ApplicationRole> _roleService;
        public HomeController(SignInService _signInService,RoleManager<ApplicationRole> role,UserManager<ApplicationUser> user)
        {
           
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}