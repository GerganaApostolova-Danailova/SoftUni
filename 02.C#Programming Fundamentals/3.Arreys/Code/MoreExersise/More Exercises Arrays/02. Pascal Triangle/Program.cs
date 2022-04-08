using System;

namespace _02._Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                int[] arr = new int[1 + i];
                int[] arr2 = new int[arr.Length+1];


                arr[0] = 1;
                arr2[0] = 1;

                if (i == 0)
                {
                    Console.WriteLine(string.Join(" ",arr));
                    Console.ReadLine();
                    arr2 = arr;
                    
                }
                else 
                {

                    if (i == (arr2.Length-1))
                    {
                    arr2[i] = arr[i - 1] + 0;
                    }
                    else
                    {
                        arr2[i]= arr[i - 1] + arr[i];
                    }
                    Console.WriteLine(string.Join(" ",arr2));
                    arr2 = arr;
                }


            }
        }
    }
}
