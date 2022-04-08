using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace _05._Multiply_Big_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            //string bigNumString = Console.ReadLine();
            //bigNumString = bigNumString.TrimStart(new char[] { '0' });
            //char[] bigNum = bigNumString.ToCharArray();
            //int number = int.Parse(Console.ReadLine());

            //if (number == 0)
            //{
            //    Console.WriteLine("0");
            //    return;
            //}
            //List<string> newNum = new List<string>();

            //int parse = 0;
            //for (int i = bigNum.Length - 1; i >= 0; i--)
            //{
            //    parse = (int.Parse(Convert.ToString(bigNum[i])) * number) + parse;
            //    newNum.Insert(0, (parse % 10).ToString());
            //    parse /= 10;
            //}


            //if (parse > 0)
            //{
            //    Console.WriteLine($"{parse}{string.Join("", newNum)}");
            //}
            //else
            //{
            //    Console.WriteLine($"{string.Join("", newNum)}");
            //}

            string bigNum = Console.ReadLine();
            int num = int.Parse(Console.ReadLine());

            StringBuilder result = new StringBuilder();

            int onMind = 0;

            for (int i = bigNum.Length - 1; i >= 0; i--)
            {
                int lastNum = int.Parse(bigNum[i].ToString());

                int res = lastNum * num + onMind;

                result.Append(res % 10);

                onMind = res / 10;
            }

            if (onMind != 0)
            {
                result.Append(onMind);
            }

            string lastresult = string.Join("", result.ToString().Reverse()).TrimStart('0');

            if (lastresult == string.Empty)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(lastresult);
            }

        }
    }
}
