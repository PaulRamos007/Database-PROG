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
    public class TechnicianController : Controller
    {
        // GET: Technician
        public ActionResult Index(int id)
        {
            var context = new TechSupportEntities();

            Technician technicians = context.Technicians.FirstOrDefault(x => x.TechID == id);

            return View(technicians);
        }

        public ActionResult TechnicianList(string searchTerm)
        {
            var context = new TechSupportEntities();

            List<Technician> technicians = context.Technicians.ToList();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                technicians = technicians.Where(c => c.Name.IndexOf(searchTerm, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
            }

            return View(technicians);
        }

        public ActionResult AddTech(int id = 0)
        {
            var context = new TechSupportEntities();

            Technician technicians = context.Technicians.FirstOrDefault(x => x.TechID == id);

            if (technicians == null)
            {
                technicians = new Technician();
            }

            return View(technicians);
        }

        [HttpPost]
        public ActionResult AddTech(Technician technicians)
        {
            var context = new TechSupportEntities();
            try
            {
                context.Technicians.AddOrUpdate(technicians);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                //Display error message
                MessageBox.Show(ex.ToString());
            }
            return View(technicians);
        }
    }
}