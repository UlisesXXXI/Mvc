using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace jim.Frontal.Controllers
{
    public class BaseController : Controller
    {
        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            return base.BeginExecute(requestContext, callback, state);
        }

        public ActionResult Error()
        {
            return View("_Error");
        }
    }
}