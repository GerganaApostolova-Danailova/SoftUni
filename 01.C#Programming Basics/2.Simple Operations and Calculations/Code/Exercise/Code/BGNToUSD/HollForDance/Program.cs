using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollForDance
{
    class Program
    {
        static void Main(string[] args)
        {
            Double LenghtOfHall = Double.Parse(Console.ReadLine());
            Double WightOfHall = Double.Parse(Console.ReadLine());
            Double WardrobeSide = Double.Parse(Console.ReadLine());
            Double WardrobeArea = WardrobeSide * WardrobeSide;
            Double HallArea = LenghtOfHall * WightOfHall;
            Double BenchSize = HallArea / 10;
            Double DancinSpace = HallArea - BenchSize - WardrobeArea;
            Double OneHumanSpace = (40 + 7000)*0.0001;
            Double HumansInHall = DancinSpace / OneHumanSpace;
            Console.WriteLine(Math.Floor(HumansInHall));
        }
    }
}
