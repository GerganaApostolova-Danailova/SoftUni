using System;

namespace _08._Beer_Kegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double volume = 0;
            double maxVolume = double.MinValue;
            string name = string.Empty;

            for (int i = 0; i < n; i++)
            {
                string model = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                volume = Math.PI * Math.Pow(radius,2) * height;

                if (volume > maxVolume)
                {
                    maxVolume = volume;
                    name = model;
                    
                }

            }
            Console.WriteLine(name);
        }
    }
}
