using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nameWars
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int maxCombination = 0;
            string winner = string.Empty;

            while (name != "STOP")
            {
                int currentSum = 0;
                for ( int i = 0; i < name.Length; i++)
                {
                    currentSum += name[i];
                }
                if (currentSum > maxCombination)
                {
                    maxCombination = currentSum;
                    winner = name;
                }
                
                name = Console.ReadLine();
            }
            Console.WriteLine($"Winner is {winner} - {maxCombination}!");
        }
    }
}
