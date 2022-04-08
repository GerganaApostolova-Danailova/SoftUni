using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;

namespace _01._Day_of_Week
{
    class Program
    {
        static void Main(string[] args)
        {
            string dateAsText = Console.ReadLine();

            DateTime date = DateTime.ParseExact(dateAsText,"d-M-yyyy",CultureInfo.InvariantCulture);

            Console.WriteLine(date.DayOfWeek);
        }
    }
}
