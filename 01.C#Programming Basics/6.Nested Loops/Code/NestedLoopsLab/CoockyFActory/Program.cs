using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoockyFActory
{
    class Program
    {
        static void Main(string[] args)
        {
            int partidas = int.Parse(Console.ReadLine());


            for (int i = 1; i <= partidas; i++)
            {
                string ingredient = Console.ReadLine();

                bool containsEggs = false;
                bool containsFlour = false;
                bool containsSugar = false;
                

                while (true)
                {
                    

                    if (ingredient == "eggs")
                    {
                        containsEggs = true;
                    }
                    else if (ingredient == "flour")
                    {
                        containsFlour = true;
                    }
                    else if (ingredient == "sugar")
                    {
                        containsSugar = true;
                    }
                    else if (ingredient == "Bake!")
                    {
                        if (containsSugar&&containsFlour&&containsEggs==true)
                        {
                            Console.WriteLine($"Baking batch number {i}...");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("The batter should contain flour, eggs and sugar!");
                        }

                        
                    }
                    ingredient = Console.ReadLine();
                }
                               

            }

        }
    }
}
