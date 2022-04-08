using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Animal
    {
        private const string Error = "Invalid input!";

        private string name;
        private int age;
        private string gender;

        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name
        {
            get
            {
                return name;
            }
            protected set
            {
                if (IsNotValid(value))
                {
                    throw new ArgumentException(Error);
                }
                name = value;
            }
        }


        public int Age
        {
            get
            {
                return age;
            }
            protected set
            {
                if (IsNotValid(value.ToString()) || value < 0)
                {
                    throw new ArgumentException(Error);
                }
                age = value;
            }
        }


        public string Gender
        {
            get
            {
                return gender;
            }
            protected set
            {
                if (IsNotValid(value))
                {
                    throw new ArgumentException(Error);
                }
                gender = value;
            }
        }

        private bool IsNotValid(string value)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                return true;
            }

            return false;
        }

        public virtual string ProduceSound()
        {
            return string.Empty;
        }

        public override string ToString()
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.GetType().Name}");
            sb.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            sb.AppendLine($"{ProduceSound()}");

            return sb.ToString().Trim();
        }
    }
}
