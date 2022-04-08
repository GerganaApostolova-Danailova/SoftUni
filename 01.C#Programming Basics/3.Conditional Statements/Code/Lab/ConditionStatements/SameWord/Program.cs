using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SameWord
{
    class Program
    {
        static void Main(string[] args)
        {
            string FurstWord = Console.ReadLine();
            string SecondWord = Console.ReadLine();
            FurstWord = FurstWord.ToUpper();
            SecondWord = SecondWord.ToUpper();

            if (FurstWord==SecondWord)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
