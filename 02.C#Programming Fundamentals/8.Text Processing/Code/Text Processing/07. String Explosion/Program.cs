using System;

namespace _07._String_Explosion
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string[] splitedinput = input
                .Split(">");

            string result = splitedinput[0];

            int remainingpower = 0;

            for (int i = 1; i < splitedinput.Length; i++)
            {
                result += ">";

                int power = int.Parse(splitedinput[i][0].ToString()) + remainingpower;

                if (power > splitedinput[i].Length)
                {
                    remainingpower = power - splitedinput[i].Length;
                }
                else
                {
                    result += splitedinput[i].Substring(power);
                }
            }
            Console.WriteLine(result);
        }
    }
}
