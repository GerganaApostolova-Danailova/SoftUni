using System;
using System.Collections.Generic;
using System.Text;

namespace _04._Students
{
    public class Student
    {
        public Student(string firstName, string lastName, int age, string homeTown)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.HomeTown = homeTown;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string HomeTown { get; set; }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} is {this.Age} years old.";
        }
    }
}
