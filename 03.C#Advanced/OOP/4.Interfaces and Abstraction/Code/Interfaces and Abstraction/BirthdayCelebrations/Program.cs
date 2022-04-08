using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebrations
{
    public class Program
    {
        static BirthdayParty BirthdayParty;

        public static void Main()
        {
            List<BirthdayParty> BirthdayPartys = new List<BirthdayParty>();

            while (true)
            {
                string[] input = Console.ReadLine().Split();

                if (input[0] == "End")
                {
                    break;
                }

                string type = input[0];
                string name = input[1];

                if (type == "Citizen")
                {
                    int age = int.Parse(input[2]);
                    string id = input[3];
                    string birthday = input[4];


                    BirthdayParty = new BirthdayParty(name, age, id, birthday);
                }
                else if (type == "Pet")
                {
                    string birthday = input[2];
                    BirthdayParty = new BirthdayParty(name, birthday);
                }
                else
                {
                    continue;
                }

                BirthdayPartys.Add(BirthdayParty);
            }

            string specificYear = Console.ReadLine();

            BirthdayPartys = BirthdayPartys
                .Where(x => x.Birthday.EndsWith(specificYear))
                .ToList();

            if (BirthdayPartys.Any())
            {
                Console.WriteLine(string.Join(Environment.NewLine, BirthdayPartys));
            }
        }
    }
}
