using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> people;

        public void AddMember(Person person)
        {
            this.people.Add(person);
        }

        public Family()
        {
            this.people = new List<Person>();
        }

        public Person GetOldestMember()
        {
            return people.OrderByDescending(a => a.Age).FirstOrDefault();
        }
    }
}
