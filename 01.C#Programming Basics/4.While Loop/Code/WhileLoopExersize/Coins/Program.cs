using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            
                double change = double.Parse(Console.ReadLine());
                int countCoins = 0;
                change = Math.Floor(change * 100); // change in coins

                while (change > 0)
                {
                    if (change >= 200)
                    {
                        change = change - 200;
                        countCoins++;
                    }
                    else if (change >= 100)
                    {
                        change = change - 100;
                        countCoins++;
                    }
                    else if (change >= 50)
                    {
                        change = change - 50;
                        countCoins++;
                    }
                    else if (change >= 20)
                    {
                        change = change - 20;
                        countCoins++;
                    }
                    else if (change >= 10)
                    {
                        change = change - 10;
                        countCoins++;
                    }
                    else if (change >= 5)
                    {
                        change = change - 5;
                        countCoins++;
                    }
                    else if (change >= 2)
                    {
                        change = change - 2;
                        countCoins++;
                    }
                    else if (change >= 1)
                    {
                        change = change - 1;
                        countCoins++;
                    }
                }
                Console.WriteLine(countCoins);

            }
        }
    }

   