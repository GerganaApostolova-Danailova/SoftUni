using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;

namespace _05._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] boxOfCloathing = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> boxes = new Stack<int>(boxOfCloathing);

            int defoltCapasityOfRack = int.Parse(Console.ReadLine());

            int capaasity = defoltCapasityOfRack;
            int counterOfBoxes = 0;


            if (boxes.Sum() >= defoltCapasityOfRack)
            {
            counterOfBoxes = 1;
            }


            while (boxes.Count > 0)
            {
                int currentCloathing = boxes.Peek();

                if (capaasity - currentCloathing >= 0)
                {
                    capaasity -= currentCloathing;
                    boxes.Pop();
                    
                }
                else
                {
                    counterOfBoxes++;
                    capaasity = defoltCapasityOfRack;
                }
            }
            Console.WriteLine(counterOfBoxes);
        }
    }
}
