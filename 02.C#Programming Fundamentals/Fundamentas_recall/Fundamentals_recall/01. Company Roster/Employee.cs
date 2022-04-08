using System;
using System.Collections.Generic;
using System.Text;

namespace _01._Company_Roster
{
    public class Employee
    {
        public Employee(string name, decimal salary, string department)
        {
            this.Name = name;
            this.Salary = salary;
            this.Department = department;
        }

        public string Name { get; set; }

        public decimal Salary { get; set; }

        public string Department { get; set; }
    }
}
