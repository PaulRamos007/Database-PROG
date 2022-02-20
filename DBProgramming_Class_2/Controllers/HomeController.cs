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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var context = new BooksEntities();

            List<Product> products = context.Products.OrderByDescending(x => x.InvoiceLineItems.Count()).ToList();

            return View(products);
        }

        public ActionResult AddProduct(string id)
        {
            var context = new BooksEntities();
            
            Product products = context.Products.FirstOrDefault(x => x.ProductCode == id);

            if (products == null)
            {
                products = new Product();
            }

            return View(products);
        }

        [HttpPost]
        public ActionResult AddProduct(Product products)
        {
            var context = new BooksEntities();
            try
            {
                context.Products.AddOrUpdate(products);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                //Display error message
                MessageBox.Show(ex.ToString());
            }
            return View(products);
        }
    }
}