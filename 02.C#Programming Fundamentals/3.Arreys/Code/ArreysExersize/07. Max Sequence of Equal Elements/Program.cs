using System;
using System.Linq;

namespace _07._Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            



            int count1 = 0;
            int maxCounter = int.MinValue;
            int value = 0;


            for (int i = 0; i < arr.Length-1; i++)
            {
                if (arr[i] == arr [i+1])
                {
                    count1++;
                   

                    
                }
                if (count1 == arr.Length)
                {
                    
                    Console.WriteLine(arr);
                    return;
                }
                if (count1 > maxCounter)
                {
                    maxCounter = count1;
                    value = arr[i];
                }
                else if(arr[i] != arr[i + 1])
                {
                
                    count1 = 0;
                    continue;
                   
                }               
            }
            for (int j = 0; j < maxCounter + 1; j++)
            {
                Console.Write(value + " ");
            }
        }
    }
}
