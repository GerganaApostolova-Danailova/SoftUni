using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeBureau
{
    class Program
    {
        static void Main(string[] args)
        {
            int NumberBitkoins = int.Parse(Console.ReadLine());
            double NumberChainees = double.Parse(Console.ReadLine());
            double Commission = double.Parse(Console.ReadLine());
            int LevaBitkoins = NumberBitkoins * 1168;
            double DolarChainees = NumberChainees * 0.15;
            double ChaneesToLev = DolarChainees * 1.76;
            double AllMoney = LevaBitkoins + ChaneesToLev;
            double AllMoneyEuro = AllMoney / 1.95;
            double Commision = AllMoneyEuro * (Commission / 100);
            double Score = AllMoneyEuro - Commision;
            Console.WriteLine($"{Score:F2}");
        }
    }
}
