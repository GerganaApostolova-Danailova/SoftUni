using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrekkingEquipments
{
    class Program
    {
        static void Main(string[] args)
        {
            int NumberOfClimber = int.Parse(Console.ReadLine());
            int NumberOfCarabiner = int.Parse(Console.ReadLine());
            int NumberOfRope = int.Parse(Console.ReadLine());
            int NumberOfPicelle = int.Parse(Console.ReadLine());
            int PrieceOfCarabiner = NumberOfCarabiner * 36;
            //Console.WriteLine(PrieceOfCarabiner);
            double PriceOfRope = NumberOfRope * 3.60;
            //Console.WriteLine(PriceOfRope);
            double PriceOfPicelles = NumberOfPicelle * 19.80;
            //Console.WriteLine(PriceOfPicelles);
            double PriceForOneClimber = PriceOfPicelles + PriceOfRope + PrieceOfCarabiner;
            //Console.WriteLine(PriceForOneClimber);
            double PriceForAllClimber = PriceForOneClimber * NumberOfClimber;
           // Console.WriteLine(PriceForAllClimber);
            double PriseWithDDS = PriceForAllClimber + ((PriceForAllClimber * 20) / 100);
            Console.WriteLine($"{PriseWithDDS:F2}");
        }
    }
}
