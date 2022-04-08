using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public class BirthdayParty : ICitizen, IPet, IRobot
    {
        public BirthdayParty(string name, int age, string id, string birthday)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthday = birthday;
        }

        public BirthdayParty(string name, string birthday)
        {
            this.Name = name;
            this.Birthday = birthday;
        }

        public string Name { get; }

        public int Age { get; }

        public string Id { get; }

        public string Birthday { get; }

        public string Model { get; }

        public override string ToString()
        {
            return this.Birthday;
        }
    }
}
