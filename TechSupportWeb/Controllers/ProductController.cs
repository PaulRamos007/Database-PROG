using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

        public ActionResult ProductList()
        {
            var context = new TechSupportEntities();

            List<Product> products = context.Products.ToList();

            return View(products);
        }
    }
}