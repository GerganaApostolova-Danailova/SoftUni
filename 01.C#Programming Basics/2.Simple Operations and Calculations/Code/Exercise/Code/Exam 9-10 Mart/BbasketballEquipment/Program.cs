using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BbasketballEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            int YearTax = int.Parse(Console.ReadLine());
            double BaskeballShoes = YearTax - (0.4 * YearTax);
            //Console.WriteLine(BaskeballShoes);
            double BasketballClothing = BaskeballShoes - (0.2 * BaskeballShoes);
            //Console.WriteLine(BasketballClothing);
            double BasketballBall = 0.25 * BasketballClothing;
            //Console.WriteLine(BasketballBall);
            double BasketballAcsesoaries = 0.2 * BasketballBall;
           // Console.WriteLine(BasketballAcsesoaries);
            double EquipmentPrice = YearTax + BaskeballShoes + BasketballClothing + BasketballBall + BasketballAcsesoaries;
            Console.WriteLine($"{EquipmentPrice:F2}");
        }
    }
}