using System;
using System.Collections.Generic;
using System.Linq;

namespace One
{
    class Program
    {
        static void Main(string[] args)
        {
            double sideSize = double.Parse(Console.ReadLine());
            int numOfPapers = int.Parse(Console.ReadLine());
            double shettOfPaperCover = double.Parse(Console.ReadLine());

            double totalArea = (sideSize * sideSize) * 6;

            double areaOfPaper = 0;

            for (int i = 1; i <= numOfPapers; i++)
            {
                if (i % 3 == 0)
                {
                    areaOfPaper += shettOfPaperCover * 0.25;
                }
                else
                {
                    areaOfPaper += shettOfPaperCover;
                }
            }

            double percent = (areaOfPaper * 100) / totalArea;

            Console.WriteLine($"You can cover {percent:f2}% of the box.");
        }
    }
}
