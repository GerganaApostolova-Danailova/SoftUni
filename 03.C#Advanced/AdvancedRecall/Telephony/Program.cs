using System;

namespace Telephony
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string[] webSites = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < numbers.Length; i++)
            {
                try
                {
                    ICalling calling = new Smartphone();
                    calling.GetCall(numbers[i]);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            for (int i = 0; i < webSites.Length; i++)
            {
                try
                {
                    IBrowsing browsing = new Smartphone();
                    browsing.GetBrowse(webSites[i]);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
