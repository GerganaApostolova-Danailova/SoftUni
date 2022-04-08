using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            int target = 10000;
            int currentSteps = 0;

            while (currentSteps <= target)
            {
                string command = Console.ReadLine();

                if (command == "Going home")
                {
                    currentSteps += int.Parse(Console.ReadLine());
                    if (currentSteps < target)
                    {
                        Console.WriteLine($"{target - currentSteps } more steps to reach goal.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Goal reached! Good job!");
                        break;
                    }
                }
                else
                {
                    currentSteps += int.Parse(command);

                    if (currentSteps >= target)
                    {
                        Console.WriteLine("Goal reached! Good job!");
                        break;
                    }
                }
            }


        }
    }
}
