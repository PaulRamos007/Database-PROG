using DBProgramming_Class_I.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DBProgramming_Class_I.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // init the context
            var context = new CompanyEntities();

            // creating list of employees
            List<Employee> employees = context.Employees
                .Where(x =>
                   (x.First_Name.ToLower().IndexOf("b") == -1) &&
                   (x.Last_Name.ToLower().IndexOf("b") == -1) &&
                    x.First_Name != null &&
                    x.Dept_Id != null)
                .OrderBy(x =>
                    x.First_Name)
                .ToList();

            string searchTerm = Request.QueryString.Get("searchTerm");
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                List<string> andSearchTerm = searchTerm.Split('+').ToList();
                foreach (var s in searchTerm)
                {
                    employees = employees
                    .Where(x =>
                    x.First_Name.ToLower().IndexOf(s) != -1 ||
                    x.Last_Name.ToLower().IndexOf(s) != -1 ||
                    x.Department.Dept_Name.ToLower().Contains(s)
                    ).ToList();
                }
            }
            // creating list of departments
            List<Department> departments = context.Departments.OrderBy(x => x.Dept_Name).ToList();

            CombinedList combinedLists = new CombinedList();
            combinedLists.Employees = employees;
            combinedLists.Departments = departments;

            // creating a Model to return to the View
            List<object> objectForFrontEnd = new List<object>();
            // add employees to Model -> Model[0]
            objectForFrontEnd.Add(employees);
            // add dept. to Model -> Model[1]
            objectForFrontEnd.Add(departments);

            // return Model to View
            return View(combinedLists);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult DeleteEmployee(int empId)
        {
            //TODO: Delete employee from Database
            ////

            var context = new CompanyEntities();
            List<Employee> employees = context.Employees.ToList();
            //LINQ
            var employeeToRemove = employees.FirstOrDefault(x => x.Emp_Id == empId);

            context.Employees.Remove(employeeToRemove);
            context.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpsertEmployee(Employee employee)
        {
            Random rnd = new Random();

            if (employee.Emp_Id == 0)
            {
                employee.Emp_Id = rnd.Next(1, 300000000);
            }

            var context = new CompanyEntities();
            try
            {
                context.Employees.AddOrUpdate(employee);
                context.SaveChanges();

                return Json(true);
            }
            catch (Exception)
            {
                return Json(false);
            }
        }
    }
}