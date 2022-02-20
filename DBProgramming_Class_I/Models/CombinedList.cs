using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBProgramming_Class_I.Models
{
    public class CombinedList
    {
        public List<Employee> Employees { get; set; }
        public List<Department> Departments { get; set; }
    }
}