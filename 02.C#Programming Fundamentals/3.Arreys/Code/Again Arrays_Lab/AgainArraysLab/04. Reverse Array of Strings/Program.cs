using System;

namespace _04._Reverse_Array_of_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine()
                .Split();

            for (int i = arr.Length-1; i >= 0; i--)
            {
                Console.Write(arr[i] + " ");
            }
        }
    }
}
