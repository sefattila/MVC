using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18_SOLIDPrensibleri._01_SingleResponsibility.BadImplementation
{
    public class Employee
    {
        //Fields
        private string fullName;
        private string dateObject;
        private double salary;

        //Properties
        //...
        public double CalculateEmployeeSalary { get; set; }
        public double CalculateTaxOnSalary { get; set; }

        public void saveEmployee()
        {

        }

        public void UpdateEmployee()
        {

        }

    }
}
