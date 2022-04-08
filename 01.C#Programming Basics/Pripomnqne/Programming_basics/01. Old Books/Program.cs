using System;

namespace _01._Old_Books
{
    class Program
    {
        static void Main(string[] args)
        {
            string findBook = Console.ReadLine();
            string currentBook = Console.ReadLine();

            int count = 0;

            bool isFindBook = false;

            while (!(findBook == currentBook))
            {
                if (currentBook == "No More Books")
                {
                    isFindBook = true;
                    break;
                }
                count++;

                currentBook = Console.ReadLine();
            }

            if (findBook != currentBook && !isFindBook)
            {
                Console.WriteLine($"You checked {count} books and found it.");
            }

            if (isFindBook)
            {
                Console.WriteLine("The book you search is not here!");
                Console.WriteLine($"You checked {count} books.");
            }
            else
            {
                Console.WriteLine($"You checked {count} books and found it.");
            }
        }
    }
}
