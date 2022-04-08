using System;
using System.Linq;

namespace EX07_Truck_Tour
{
    class CalculateCircle
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());

            int[] pumps = new int[N];

            for (int i = 0; i < N; i++)
            {
                int[] integers = Console.ReadLine().Split().Select(int.Parse).ToArray();
                pumps[i] = integers[0] - integers[1];
            }

            int current = 0;
            int position = 0;

            for (int i = 0; i < N; i++)
            {
                current += pumps[i];

                if (current < 0)
                {
                    current = 0;
                    position = i + 1;
                }
            }
            Console.WriteLine(position);
        }
    }
}