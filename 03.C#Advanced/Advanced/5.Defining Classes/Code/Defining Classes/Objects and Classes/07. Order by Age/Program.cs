using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;

namespace _07._Order_by_Age
{
    public class People
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }


        public People(string name, string id, int age)
        {
            this.Name = name;
            this.ID = id;
            this.Age = age;

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<People> peoples = new List<People>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                string[] command = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);


                string name = command[0];
                string id = command[1];
                int age = int.Parse(command[2]);

                People currentPeople = new People(name, id, age);
                peoples.Add(currentPeople);
            }

            foreach (var people in peoples.OrderBy(x=>x.Age))
            {
                Console.WriteLine($"{people.Name} with ID: {people.ID} is {people.Age} years old.");
            }

        }
    }
}
