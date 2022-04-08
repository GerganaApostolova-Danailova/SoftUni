using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            string NameOfBook = Console.ReadLine();
            int CapasityOfLibrary = int.Parse(Console.ReadLine());

            int counter = 0;
            int NumberOfBook = 0;

            while (counter < CapasityOfLibrary)
            {
                string NextBook = Console.ReadLine();

                if (NameOfBook == NextBook)
                {
                    NumberOfBook += counter;
                    Console.WriteLine($"You checked {NumberOfBook} books and found it.");
                    break;
                }

                
                
                    counter++;
                

                if (counter == CapasityOfLibrary)
                {
                    Console.WriteLine("The book you search is not here!");
                    Console.WriteLine($"You checked {counter} books.");
                    

                }



            }
        }
    }
}
