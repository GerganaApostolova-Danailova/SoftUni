using System;

namespace _9._Padawan_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double bujet = double.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());
            double saberPrice = double.Parse(Console.ReadLine());
            double robesPrice = double.Parse(Console.ReadLine());
            double beltPrice = double.Parse(Console.ReadLine());

            double finalMoney = 0;

            double moreTenPersent = Math.Ceiling(studentsCount + (studentsCount * 0.1));

            if (studentsCount >=6)
            {
                int sixBeltsFree = studentsCount / 6;
                int finalStudentsCount = studentsCount - sixBeltsFree;

                finalMoney = (saberPrice * moreTenPersent) + (robesPrice * studentsCount) + (beltPrice * finalStudentsCount);

            }
            else
            {
                finalMoney = (saberPrice * moreTenPersent) + (robesPrice * studentsCount) + (beltPrice * studentsCount);
            }

            if(finalMoney <= bujet)
            {
               
                Console.WriteLine($"The money is enough - it would cost {finalMoney:f2}lv.");
            }
            else if (finalMoney > bujet)
            {
                double cost = finalMoney - bujet;
                Console.WriteLine($"Ivan Cho will need {cost:f2}lv more.");
            }
        }
    }
}
