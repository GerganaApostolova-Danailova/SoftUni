using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualSumEvenOrOddPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            for (int i = num1; i <= num2; i++)
            {
                string curruntNum = i.ToString();
                int evenSum = 0;
                int oddSum = 0;

                for (int j = 0; j < curruntNum.Length; j++)
                {
                    int curruntNUmDigital = int.Parse(curruntNum[j].ToString());
                   

                    if (j % 2 == 0)
                    {
                        evenSum += curruntNUmDigital;
                    }
                    else
                    {
                        oddSum += curruntNUmDigital;
                    }
                }
                if(evenSum == oddSum)
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}
