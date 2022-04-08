using System;
using System.Linq;

namespace _08._Condense_Array_to_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            if (nums.Length ==1 )
            {
                Console.WriteLine($"{nums[0]}");
                return;
            }

            int[] condensed = new int[nums.Length - 1];

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < condensed.Length - i; j++)
                {
                    condensed[j] = nums[j] + nums[j + 1];
                }
                nums = condensed;
            }

            Console.WriteLine(nums[0]);
        }
    }
}
