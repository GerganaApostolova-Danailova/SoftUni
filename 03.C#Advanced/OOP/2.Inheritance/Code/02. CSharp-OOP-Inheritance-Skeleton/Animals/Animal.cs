using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Animal : ISoundProducable
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

        public virtual string Name
        {
            get => this.name;
            protected set
            {
                if (IsNotValid(value))
                {
                    throw new ArgumentException(Error);
                }

                this.name = value;
            }
        }

        public virtual int Age
        {
            get => this.age;
            protected set
            {
                if (IsNotValid(value.ToString()) || value < 0)
                {
                    throw new ArgumentException(Error);
                }

                this.age = value;
            }
        }

        public virtual string Gender
        {
            get => this.gender;
            protected set
            {
                if (IsNotValid(value))
                {
                    throw new ArgumentException(Error);
                }

                this.gender = value;
            }
        }

        public virtual string ProduceSound()
        {
            return string.Empty;
        }

        private bool IsNotValid(string value)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.GetType().Name}");
            sb.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            sb.AppendLine($"{this.ProduceSound()}");

            return sb.ToString().TrimEnd();
        }
    }
}
