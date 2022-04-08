using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestPlayer
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;
            int maxGoal = int.MinValue;
            string name = string.Empty;
            // int hethTrik = 0;

            while ((command = Console.ReadLine()) != "END")
            {
                int numberOfGolas = int.Parse(Console.ReadLine());

                if (numberOfGolas > maxGoal)
                {
                    maxGoal = numberOfGolas;
                    name = command;
                    //if (maxGoal >=3 && maxGoal < 10)
                    //{
                    //    hethTrik = maxGoal;
                    //    name = command;
                    //}

                }
                if (numberOfGolas >= 10)
                {
                    name = command;
                    maxGoal = numberOfGolas;
                    break;
                }



            }
            Console.WriteLine($"{name} is the best player!");

            if (command == "END")
            {
                if (maxGoal >= 10)
                {
                    Console.WriteLine($"He has scored {maxGoal} goals and made a hat-trick !!!");
                }
                else if (maxGoal >= 3 && maxGoal < 10)
                {
                    Console.WriteLine($"He has scored {maxGoal} goals and made a hat-trick !!!");
                }
                else if (maxGoal < 3)
                {
                    Console.WriteLine($"He has scored {maxGoal} goals.");
                }

            }

            else if (maxGoal >= 10)
            {
                Console.WriteLine($"He has scored {maxGoal} goals and made a hat-trick !!!");
            }
            //else if (maxGoal >= 3 && maxGoal < 10)
            //{
            //    Console.WriteLine($"He has scored {maxGoal} goals and made a hat-trick !!!");
            //}
            //else if (maxGoal < 3)
            //{
            //    Console.WriteLine($"He has scored {maxGoal} goals.");
            //}


        }
    }
}
