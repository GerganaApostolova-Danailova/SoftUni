using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace _02._Oldest_Family_Member
{
    public class Family
    {
        public Family()
        {
            this.Persons = new List<Person>();
        }

        public List<Person> Persons { get; set; }

        public void AddMember(Person member)
        {
            this.Persons.Add(member);
        }

        public Person GetOldestMember()
        {
            return Persons.OrderByDescending(x => x.Age).First();
        }
    }
}
