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
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index(int id)
        {
            var context = new TechSupportEntities();

            Customer customers = context.Customers.FirstOrDefault(x => x.CustomerID == id);

            return View(customers);
        }

        public ActionResult CustomersList(string searchTerm)
        {
            var context = new TechSupportEntities();

            List<Customer> customers = context.Customers.ToList();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                customers = customers.Where(c => c.Name.IndexOf(searchTerm, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
            }

            return View(customers);
        }

        public ActionResult AddCustomer(int id = 0)
        {
            var context = new TechSupportEntities();

            Customer customers = context.Customers.FirstOrDefault(x => x.CustomerID == id);

            if (customers == null)
            {
                customers = new Customer();
            }

            return View(customers);
        }

        [HttpPost]
        public ActionResult AddCustomer(Customer customers)
        {
            var context = new TechSupportEntities();
            try
            {
                context.Customers.AddOrUpdate(customers);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                //Display error message
                MessageBox.Show(ex.ToString());
            }
            return View(customers);
        }
    }
}