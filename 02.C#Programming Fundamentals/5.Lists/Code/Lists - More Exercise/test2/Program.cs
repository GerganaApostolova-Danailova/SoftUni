using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test2
{
    class Program
    {
        static void Main(string[] args)
        {
            string commend = Console.ReadLine();

            commend.Remove(6, 1);
            Console.WriteLine(commend);
            
        }
    }
}
