using System;

namespace _01._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            int[] train = new int[num];
            int sum = 0;
            

            for (int i = 0; i < num; i++)
            {
                train[i] = int.Parse(Console.ReadLine());
                   
                sum += train[i];
            }

                Console.WriteLine(string.Join(" ",train));
                        
            Console.WriteLine(sum);
        }
    }
}
