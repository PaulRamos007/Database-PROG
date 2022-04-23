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
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index(string id)
        {
            var context = new TechSupportEntities();

            Product products = context.Products.FirstOrDefault(x => x.ProductCode == id);

            return View(products);
        }

        public ActionResult ProductList(string searchTerm)
        {
            var context = new TechSupportEntities();

            List<Product> products = context.Products.ToList();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                products = products.Where(p => p.Name.IndexOf(searchTerm, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
            }

            return View(products);
        }

        public ActionResult AddProduct(string id)
        {
            var context = new TechSupportEntities();

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
            var context = new TechSupportEntities();
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