using System;

namespace _04._Back_In_30_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            int allMinutes = (hours * 60) + minutes + 30;

            int hours2 = allMinutes / 60;
            int minutes2 = allMinutes % 60;

            if (hours2 == 24 )
            {
                hours2 = 0;
            }
            if (minutes2 < 10)
            {
                Console.WriteLine($"{hours2}:0{minutes2}");
            }
            else
            {
                Console.WriteLine($"{hours2}:{minutes2}");

            }
        }
    }
}
