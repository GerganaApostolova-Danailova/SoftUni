using System;

namespace _01._Cooking_Masterclass
{
    class Program
    {
        static void Main(string[] args)
        {
            double bujet = double.Parse(Console.ReadLine());
            int numberOfStudents = int.Parse(Console.ReadLine());
            double priceOfFlour = double.Parse(Console.ReadLine());
            double priceOfEgg = double.Parse(Console.ReadLine());
            double priceOfApron = double.Parse(Console.ReadLine());

            int freePackeges = 0;

            double apron = priceOfApron * (Math.Ceiling(numberOfStudents + (numberOfStudents * 0.2)));
            double eggs = priceOfEgg * 10 * numberOfStudents;

            if (numberOfStudents >= 5)
            {
                freePackeges = numberOfStudents / 5;
            }
           

            double flour = priceOfFlour * (numberOfStudents - freePackeges);


            double currentBujet = apron + eggs + flour;

            if (bujet >= currentBujet)
            {
                Console.WriteLine($"Items purchased for {currentBujet:f2}$.");
            }
            else
            {
                Console.WriteLine($"{(currentBujet - bujet):f2}$ more needed.");
            }

        }
    }
}
