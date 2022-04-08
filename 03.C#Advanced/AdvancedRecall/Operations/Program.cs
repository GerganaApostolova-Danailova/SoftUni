using System;

namespace Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            MathOperations mo = new MathOperations();

            Console.WriteLine(mo.Add(1,2));
            Console.WriteLine(mo.Add(1.1,2.2,3.3));
            Console.WriteLine(mo.Add(1.1m,2.2m,3.3m));
        }
    }
}
