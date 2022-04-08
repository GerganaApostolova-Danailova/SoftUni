using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;

namespace _3._Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] nums = Console.ReadLine()
                .Split();

            Stack<string> sum = new Stack<string>(nums.Reverse());

            while (sum.Count > 1)
            {
                int firstNum = int.Parse(sum.Pop());
                string operators = sum.Pop();
                int secondNum = int.Parse(sum.Pop());

                if (operators == "-")
                {
                    sum.Push((firstNum - secondNum).ToString());
                }
                else
                {
                    sum.Push((firstNum + secondNum).ToString());
                }
            }

            Console.WriteLine(sum.Peek());
        }
    }
}
