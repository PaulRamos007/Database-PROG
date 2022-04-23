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
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Index(int id)
        {
            var context = new TechSupportEntities();

            Registration registrations = context.Registrations.FirstOrDefault(x => x.CustomerID == id);

            return View(registrations);
        }

        public ActionResult RegistrationList(string searchTerm)
        {
            var context = new TechSupportEntities();

            List<Registration> registrations = context.Registrations.ToList();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                registrations = registrations.Where(c => c.Customer.Name.IndexOf(searchTerm, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
            }

            return View(registrations);
        }

        public ActionResult AddRegistration(int id = 0)
        {
            var context = new TechSupportEntities();

            Registration registrations = context.Registrations.FirstOrDefault(x => x.CustomerID == id);

            if (registrations == null)
            {
                registrations = new Registration();
            }

            return View(registrations);
        }

        [HttpPost]
        public ActionResult AddRegistration(Registration registrations)
        {
            var context = new TechSupportEntities();
            try
            {
                context.Registrations.AddOrUpdate(registrations);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                //Display error message
                MessageBox.Show(ex.ToString());
            }
            return View(registrations);
        }
    }
}