using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        List<Person> persons = new List<Person>();

        public void AddMember(Person member)
        {
            this.persons.Add(member);
        }

        public Person GetOldestMember()
        {
            int maxAge = int.MinValue;

            Person oldestPerson = null;

            foreach (var person in this.persons)
            {
                if (person.Age > maxAge)
                {
                    maxAge = person.Age;
                    oldestPerson = person;
                }
            }

            return oldestPerson;
        }
    }
}
