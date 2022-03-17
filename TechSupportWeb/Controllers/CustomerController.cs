using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
                customers = customers.Where(c => c.Name.IndexOf(searchTerm) != -1).ToList();
            }

            return View(customers);
        }
    }
}