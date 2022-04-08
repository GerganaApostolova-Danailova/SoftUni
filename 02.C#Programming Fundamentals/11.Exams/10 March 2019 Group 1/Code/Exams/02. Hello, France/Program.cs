using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Hello__France
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split("|");

            double buget = double.Parse(Console.ReadLine());
            
            var finalPrice = new List<double>();
            
            for (int i = 0; i < input.Length; i++)
            {
                var currantTipe = input[i].Split("->");
                
                double currentPrice = double.Parse(currantTipe[1]);

                if (currantTipe[0] == "Clothes" && currentPrice <= 50 && buget >= 50)
                {
                    
                        buget -= currentPrice;
                       
                        finalPrice.Add(currentPrice * 1.4);

                }
                else if (currantTipe[0] == "Shoes" && currentPrice <= 35 && buget >= 35)
                {
                    
                        buget -= currentPrice;
                        
                        finalPrice.Add(currentPrice * 1.4);
                    
                }
                else if (currantTipe[0] == "Accessories" && currentPrice <= 20.50 && buget >= 20.50)
                {
                   
                        buget -= currentPrice;
                        
                        finalPrice.Add(currentPrice * 1.4);
                   
                }
            }
            double profit = finalPrice.Sum() - finalPrice.Sum()/1.4;
           buget += finalPrice.Sum();


            for (int j = 0; j < finalPrice.Count; j++)
            {
                Console.Write($"{finalPrice[j]:f2} ");
            }
            
            Console.WriteLine();
            
            Console.WriteLine($"Profit: {profit:f2}");

            if (buget >= 150)
            {
                Console.WriteLine("Hello, France!");
            }
            else
            {
                Console.WriteLine("Time to go.");
            }

        }
    }
}
