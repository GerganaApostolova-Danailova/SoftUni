using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberColouredEggs = int.Parse(Console.ReadLine());
            int redCounter = 0;
            int orangeCounter = 0;
            int blueCounter = 0;
            int greenCounter = 0;
            int maxColour = int.MinValue;
            string nameOfMaxColour = "";


            for (int i = 1; i <= numberColouredEggs; i++)
            {
                string ColourOfTHeEggs = Console.ReadLine();

                if (ColourOfTHeEggs == "red")
                {
                    redCounter++;

                    if (redCounter > maxColour)
                    {
                        maxColour = redCounter;
                        nameOfMaxColour = ColourOfTHeEggs;
                    }
                }
                else if (ColourOfTHeEggs == "orange")
                {
                    orangeCounter++;

                    if (orangeCounter > maxColour)
                    {
                        maxColour = orangeCounter;
                        nameOfMaxColour = ColourOfTHeEggs;
                    }
                }
                else if (ColourOfTHeEggs == "blue")
                {
                    blueCounter++;

                    if (blueCounter > maxColour)
                    {
                        maxColour = blueCounter;
                        nameOfMaxColour = ColourOfTHeEggs;
                    }
                }
                else if (ColourOfTHeEggs == "green")
                {
                    greenCounter++;

                    if (greenCounter > maxColour)
                    {
                        maxColour = greenCounter;
                        nameOfMaxColour = ColourOfTHeEggs;

                    }
                }

            }
            Console.WriteLine($"Red eggs: {redCounter}");
            Console.WriteLine($"Orange eggs: {orangeCounter}");
            Console.WriteLine($"Blue eggs: {blueCounter}");
            Console.WriteLine($"Green eggs: {greenCounter}");
            Console.WriteLine($"Max eggs: {maxColour} -> {nameOfMaxColour}");

        }
    }
}
