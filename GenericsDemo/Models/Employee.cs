using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsDemo.Models
{
   public struct Employee
    {

        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeDepartment { get; set; }
        public string EmployeeDesignation { get; set; }
        public double EmployeeSalary { get; set; }
        public string EmployeeLocation { get; set; }

        public override string ToString()
        {
            return EmployeeId + " " + EmployeeName + " " + EmployeeDepartment + " " + EmployeeDesignation + " " + EmployeeSalary + " " + EmployeeLocation;
        }
    }
}
