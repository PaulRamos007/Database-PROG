using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows;
using TechSupportWeb.Models;

namespace TechSupportWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string searchTerm)
        {
            var context = new TechSupportEntities();

            List<Incident> incidents = context.Incidents.ToList();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                incidents = incidents.Where(c => c.Customer.Name.IndexOf(searchTerm, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
            }

            return View(incidents);
        }

        public ActionResult AddIncident(int id = 0)
        {
            var context = new TechSupportEntities();

            Incident incidents = context.Incidents.FirstOrDefault(x => x.IncidentID == id);

            if (incidents == null)
            {
                incidents = new Incident();
            }

            return View(incidents);
        }

        [HttpPost]
        public ActionResult AddIncident(Incident incidents)
        {
            var context = new TechSupportEntities();
            try
            {
                context.Incidents.AddOrUpdate(incidents);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                //Display error message
                MessageBox.Show(ex.ToString());
            }
            return View(incidents);
        }
    }
}