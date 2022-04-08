using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleverLilly
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double washingMashinPrice = double.Parse(Console.ReadLine());
            int toyPrice = int.Parse(Console.ReadLine());

            int moneyForEven = 0;
            int AllEven = 0;
            int moneyToys = 0;
            int countToys = 0;
            int brotherTake = 0;
            double diff = 0.0;
            int AllMoney = 0;
            int counterForBrother = 0;

            for (int i=1; i<=age; i++)
            {
                if (i % 2 == 0)
                {
                    moneyForEven += 10;
                    AllEven += moneyForEven;
                    counterForBrother++;
                }
                else
                {
                    countToys++;
                }
            }

            moneyToys = countToys * toyPrice;
            brotherTake = 1 * counterForBrother;
            AllMoney = AllEven + moneyToys - brotherTake;
            diff = Math.Abs(washingMashinPrice - AllMoney);
           


            if ( washingMashinPrice <= AllMoney)
            {
                Console.WriteLine($"Yes! {diff:f2}");
            }
            else
            {
                Console.WriteLine($"No! {diff:f2}");
            }



        }
    }
}
