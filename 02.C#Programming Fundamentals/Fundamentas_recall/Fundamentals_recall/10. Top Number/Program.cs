using System;

namespace _10._Top_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            for (int i = 1; i < num; i++)
            {
                bool isDevisibletoEight = GetDevisibelNumber(i);

                if (isDevisibletoEight)
                {

                }
            }
        }

        private static bool GetDevisibelNumber(int i)
        {
            int[] arr = (int)i.;
            for (int z = 0; z < i.le; z++)
            {

            }
            return i % 8 == 0;
        }
    }
}
