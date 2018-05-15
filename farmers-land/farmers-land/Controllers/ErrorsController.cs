using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace farmers_land.Controllers
{
    public class ErrorsController : Controller
    {
        // GET: Errors
        public ActionResult General()
        {
            return View();
        }

        public ActionResult Http400()
        {
            return View();
        }

        public ContentResult Http401()
        {
            return Content("Unauthorised");
        }

        public ContentResult Http404()
        {
            return Content("not found");
        }

        public ActionResult Http403()
        {
            return View();
        }

        public ActionResult Http500()
        {
            return View();
        }
    }
}