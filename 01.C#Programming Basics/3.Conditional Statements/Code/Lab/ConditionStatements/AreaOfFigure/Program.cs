using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaOfFigure
{
    class Program
    {
        static void Main(string[] args)
        {
            string Figure = Console.ReadLine();
            double area = 0.0;
            switch (Figure)
            {
                case "square":
                    {
                        double a = double.Parse(Console.ReadLine());
                        area = a * a;
                        break;
                    }
                case "rectangle":
                    {
                        double a = double.Parse(Console.ReadLine());
                        double b = double.Parse(Console.ReadLine());
                        area = a * b;
                        break;
                    }
                case "circle":
                    {
                        double r = double.Parse(Console.ReadLine());
                        area = r * r * Math.PI;
                        break;

                    }
                case "triangle":
                    {
                        double a = double.Parse(Console.ReadLine());
                        double h = double.Parse(Console.ReadLine());
                        area = a * h / 2;
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Error");
                        break;
                    }
                    // Console.WriteLine($"{area:f3}");

            }

            Console.WriteLine($"{area:F3}");
        }
    }
}