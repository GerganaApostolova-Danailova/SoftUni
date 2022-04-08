using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeStadion
{
    class Program
    {
        static void Main(string[] args)
        {
            int sectorOfStadion = int.Parse(Console.ReadLine());
            int capasityOfStadion = int.Parse(Console.ReadLine());
            double priceForOneTicket = double.Parse(Console.ReadLine());

            double totalIncome = capasityOfStadion * priceForOneTicket;
            double totalIncomeForOneSector = totalIncome / sectorOfStadion;
            double moneyForCharity = (totalIncome - (totalIncomeForOneSector * 0.75)) / 8;

            Console.WriteLine($"Total income - {totalIncome:f2} BGN");
            Console.WriteLine(($"Money for charity - {moneyForCharity:f2} BGN"));


        }
    }
}

