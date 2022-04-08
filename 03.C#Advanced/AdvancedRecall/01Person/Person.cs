using System;
using System.Collections.Generic;
using System.Text;

namespace _01Person
{
    public class Person
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public virtual int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (age > 0)
                {
                    age = value;
                }
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"Name: {this.Name}, Age: {this.Age}");

            return sb.ToString();
        }
    }
}
