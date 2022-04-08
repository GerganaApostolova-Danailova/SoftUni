using System;

namespace _02._Common_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            //Hey hello 2 4
            //10 hey 4 hello  4 hello
            //S of t un i
            //of i 10 un of i un
            //i love to code
            //code i love to  code i love to

            string[] arr1 = Console.ReadLine()
                .Split();

            string[] arr2 = Console.ReadLine()
                .Split();


            for (int i = 0; i < arr2.Length; i++)
            {
                for (int j = 0; j < arr1.Length; j++)
                {
                    if (arr2[i] == arr1[j])
                    {
                        Console.Write($"{arr2[i]} ");
                    }
                }
            }
        }
    }
}
