using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadiumIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            int NumberOfSectors = int.Parse(Console.ReadLine());
            int CapasityOfStadion = int.Parse(Console.ReadLine());
            double PriceOfOneTicket = double.Parse(Console.ReadLine());
            double MoneyForOneSector = (CapasityOfStadion * PriceOfOneTicket) / NumberOfSectors;
            double AllIncome = MoneyForOneSector * NumberOfSectors;
            double MoneyForCharity = (AllIncome - (MoneyForOneSector * 0.75)) / 8;
            Console.WriteLine($"Total income - {$"{AllIncome:F2}"} BGN");
            Console.WriteLine($"Money for charity - {$"{MoneyForCharity:F2}"} BGN");

        }
    }
}
