using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechSupportWeb.Models;

namespace TechSupportWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var context = new TechSupportEntities();

            List<Incident> incidents = context.Incidents.ToList();

            return View(incidents);
        }
    }
}