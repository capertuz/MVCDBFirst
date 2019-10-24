using ContosoSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContosoSite.Controllers
{
    public class CoursesController : Controller
    {
        // GET: Courses
        public ActionResult New()
        {
            var Model = new Course();
            return View("CoursesForm", Model);
        }

        public ActionResult CoursesForm()
        {
            var Model = new Course();
            return View(Model);
        }
    }
}