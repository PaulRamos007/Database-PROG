using DBProgramming_Class_2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows;

namespace DBProgramming_Class_2.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index(int id)
        {
            var context = new BooksEntities();

            if (id == 0)
            {
                Redirect("/Customer/AddCustomer");
            }

            Customer customer = context.Customers.FirstOrDefault(x => x.CustomerID == id);

            return View(customer);
        }

        public ActionResult CustomersList(string searchTerm)
        {
            var context = new BooksEntities();

            List<Customer> customers = context.Customers.ToList();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                customers = customers.Where(c => c.Name.IndexOf(searchTerm) != -1).ToList();
            }

            return View(customers);
        }

        public ActionResult AddCustomer(int id = 0)
        {
            var context = new BooksEntities();
            Customer customer = context.Customers.FirstOrDefault(x => x.CustomerID == id);

            if (customer == null)
            {
                customer = new Customer();
            }

            return View(customer);
        }

        [HttpPost]
        public ActionResult AddCustomer(Customer customer)
        {
            var context = new BooksEntities();
            try
            {
                context.Customers.AddOrUpdate(customer);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                //Display error message
                MessageBox.Show(ex.ToString());
            }
            return View(customer);
        }
    }
}