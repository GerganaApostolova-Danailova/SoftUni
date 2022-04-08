using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopingTime
{
    class Program
    {
        static void Main(string[] args)
        {
            int TimeRest = int.Parse(Console.ReadLine());
            double PriceOnePeriferPart = double.Parse(Console.ReadLine());
            double PriceOneProgram = double.Parse(Console.ReadLine());
            double PriceFrape = double.Parse(Console.ReadLine());
            double TimeAfterFrape = TimeRest - 5;
            double TimeForPeriffer = 3 * 2;
            double TimeForPrograms = 2 * 2;
            double TimeForRelaks = TimeAfterFrape - (TimeForPeriffer + TimeForPrograms);
            double PriceForPeriffer = 3 * PriceOnePeriferPart;
            double PriceForProgram = 2 * PriceOneProgram;
            double AllSpendMoney = PriceFrape + PriceForPeriffer + PriceForProgram;
            Console.WriteLine($"{AllSpendMoney:F2}");
            Console.WriteLine(TimeForRelaks);
        }
    }
}
