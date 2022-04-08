using System;

namespace _03._Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            double peopleToMove = double.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());

            
                double recult = Math.Ceiling(peopleToMove / capacity);
                Console.WriteLine(recult);
            
        }
    }
}
