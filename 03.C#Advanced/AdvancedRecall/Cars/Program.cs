using System;

namespace Cars
{
    public class Program
    {
        static void Main(string[] args)
        {
            ICar seat = new Seat("Leon", "Gray");
            IElectrictricCar tesla = new Tesla("Model 3", "Red", 2);

            Console.WriteLine(seat.ToString());
            Console.WriteLine(tesla.ToString());
        }
    }
}
