using System;

namespace _12._Refactor_Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int sum = 0;
            int result = 0;
            bool equal = false;
            for (int ch = 1; ch <= num; ch++)
            {
                result = ch;
                while (ch > 0)
                {
                    sum += ch % 10;
                    ch = ch / 10;
                }
               equal = (sum == 5) || (sum == 7) || (sum == 11);
                Console.WriteLine("{0} -> {1}", result, equal);
                sum = 0;
                ch = result;
            }

        }
    }
}
