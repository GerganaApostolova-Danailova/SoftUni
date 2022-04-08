using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZoomagazinPetShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int NumDog = int.Parse(Console.ReadLine());
            int otherPet = int.Parse(Console.ReadLine());

            double totalSum = NumDog * 2.5 + otherPet * 4;
            Console.WriteLine($"{totalSum:f2} lv.");
        }
    }
}
