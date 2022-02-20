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
    public class InvoiceController : Controller
    {
        // GET: Invoice
        public ActionResult Index(string id)
        {
            var context = new BooksEntities();

            List<int> invoiceLineItems = context.InvoiceLineItems.Where(i => i.ProductCode == id).Select(x => x.InvoiceID).ToList();

            List<Invoice> invoices = context.Invoices.Where(i => invoiceLineItems.Contains(i.InvoiceID)).ToList();

            return View(invoices);
        }

        public ActionResult InvoiceList()
        {
            var context = new BooksEntities();

            List<Invoice> invoice = context.Invoices.ToList();

            return View(invoice);
        }

        public ActionResult AddEditInvoice(int id = 0)
        {
            var context = new BooksEntities();
            List<Customer> customers = context.Customers.ToList();
            List<Product> products = context.Products.ToList();
            List<InvoiceLineItem> lineItems = context.InvoiceLineItems.ToList();
            Invoice invoice = context.Invoices.FirstOrDefault(x => x.InvoiceID == id);

            CombinedList data = new CombinedList();
            data.Customers = customers;
            data.Products = products;
            data.InvoiceLines = lineItems;
            data.Invoices = invoice;

            if (invoice == null)
            {
                invoice = new Invoice();
            }

            return View(data);
        }

        [HttpPost]
        public ActionResult AddEditInvoice(Invoice invoice, InvoiceLineItem lines)
        {
            var context = new BooksEntities();

            try
            {
                context.Invoices.AddOrUpdate(invoice);
                context.InvoiceLineItems.AddOrUpdate(lines);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                //Display error message
                MessageBox.Show(ex.ToString());
            }
            return Redirect("/Invoice/AddEditInvoice/" + 0);
        }
    }
}