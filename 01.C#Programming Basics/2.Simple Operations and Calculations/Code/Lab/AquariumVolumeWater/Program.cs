using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquariumVolumeWater
{
    class Program
    {
        static void Main(string[] args)
        {
            Double AquariumSideOne = Double.Parse(Console.ReadLine());
            Double AquariumSideTwo = Double.Parse(Console.ReadLine());
            Double AquarHaight = Double.Parse(Console.ReadLine());
            Double PercentOfStuff = Double.Parse(Console.ReadLine());
            Double AquariumVolume = AquariumSideOne * AquariumSideTwo * AquarHaight;
            Double AquariumLitres = AquariumVolume * 0.001;
            Double PercentInPart = PercentOfStuff * 0.01;
            Double FinalScore = AquariumLitres * (1 - PercentInPart);
            Console.WriteLine($"{FinalScore:F3}");
        }
    }
}
