using System;

namespace PersonInfo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string name = Console.ReadLine();

            IFerrari ferari = new Ferrari(name);

            Console.WriteLine(ferari);
        }
    }
}
