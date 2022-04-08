using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingHall
{
    class Program
    {
        static void Main(string[] args)
        {
            double LenghtHall = double.Parse(Console.ReadLine());
            double WedhtHAll = double.Parse(Console.ReadLine());
            double BarsSide = double.Parse(Console.ReadLine());
            double HallArea = LenghtHall * WedhtHAll;
           // Console.WriteLine(HallArea);
            double BarArea = BarsSide * BarsSide;
          //  Console.WriteLine(BarArea);
            double DancingArea = HallArea * 0.19;
            //Console.WriteLine(DancingArea);
            double AreaForPeople = HallArea - BarArea - DancingArea;
            //Console.WriteLine(AreaForPeople);
            double NumberOfPeople = AreaForPeople / 3.2;
            Console.WriteLine(Math.Ceiling(NumberOfPeople));
        }
    }
}
