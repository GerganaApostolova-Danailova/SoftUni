using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;

namespace _04._Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());
            Queue<int> allFood = new Queue<int>();
            Queue<int> ordersLeft = new Queue<int>();

            int[] orders = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < orders.Length; i++)
            {
                if (foodQuantity - orders[i] >= 0)
                {
                    foodQuantity -= orders[i];
                    allFood.Enqueue(orders[i]);
                }
                else if (foodQuantity - orders[i] < 0)
                {
                    ordersLeft.Enqueue(orders[i]);
                }
            }

            Console.WriteLine(orders.Max());

            if (ordersLeft.Count > 0)
            {
                Console.Write("Orders left: ");
                Console.WriteLine(string.Join(" ", ordersLeft));
                return;
            }

            if (foodQuantity >= 0)
            {
                Console.Write("Orders complete");
            }
        }
    }
}
