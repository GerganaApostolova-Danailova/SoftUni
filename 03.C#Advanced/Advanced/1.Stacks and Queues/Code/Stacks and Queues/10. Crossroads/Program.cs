using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;

namespace _10._Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLine = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();

            string car = Console.ReadLine();

            bool isHitted = false;
            string hittedCarName = string.Empty;
            char hittedSymbol = '\0';

            int counter = 0;

            while (car != "END")
            {
                if (car != "green")
                {
                    cars.Enqueue(car);

                    car = Console.ReadLine();
                    continue;
                }

                int currentGreenLine = greenLine;

                while (currentGreenLine > 0 && cars.Count > 0)
                {
                    string currentCar = cars.Dequeue();
                    int carLenght = currentCar.Length;

                    if (currentGreenLine - carLenght >= 0)
                    {
                        currentGreenLine -= carLenght;
                        counter++;
                    }
                    else
                    {
                        currentGreenLine += freeWindow;

                        if (currentGreenLine - carLenght >= 0)
                        {

                            counter++;
                            break;
                        }
                        else
                        {
                            isHitted = true;
                            hittedCarName = currentCar;
                            hittedSymbol = currentCar[currentGreenLine];
                            break;
                        }
                    }
                }

                if (isHitted)
                {
                    break;
                }

                car = Console.ReadLine();
            }

            if (isHitted)
            {
                Console.WriteLine("A crash happened!");
                Console.WriteLine($"{hittedCarName} was hit at {hittedSymbol}.");
            }
            else
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{counter} total cars passed the crossroads.");
            }
        }
    }
}
