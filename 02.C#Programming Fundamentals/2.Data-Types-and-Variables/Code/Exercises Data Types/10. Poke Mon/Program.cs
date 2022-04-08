using System;

namespace _10._Poke_Mon
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());
            int Y = int.Parse(Console.ReadLine());

            int counter = 0;
            double halfN = N / 2.0;


            while (N >= M)
            {
                counter++;

                N -= M;

                if (N == halfN)
                {
                    if (Y > 0 )
                    {
                        N /= Y;                 
                    }
                }
            }
            Console.WriteLine(N);
            Console.WriteLine(counter);
            
        }
    }
}
