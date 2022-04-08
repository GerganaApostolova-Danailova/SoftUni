using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class Smartphone : ICalling, IBrowsing
    {
        public void GetBrowse(string webSides)
        {
            foreach (var item in webSides)
            {
                if (char.IsDigit(item))
                {
                    throw new Exception("Invalid URL!");
                }
            }
            Console.WriteLine($"Browsing: {webSides}!");
        }

        public void GetCall(string phoneNumbers)
        {
            foreach (var item in phoneNumbers)
            {
                if (!char.IsDigit(item))
                {
                    throw new Exception("Invalid number!");
                }
            }
            if (phoneNumbers.Length == 10)
            {
                Console.WriteLine($"Calling... {phoneNumbers}");
            }
            else
            {
                Console.WriteLine($"Dialing... {phoneNumbers}");
            }

        }

    }
}
