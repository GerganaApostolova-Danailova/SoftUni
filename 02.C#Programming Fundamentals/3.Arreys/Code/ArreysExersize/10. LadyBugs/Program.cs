using System;
using System.Linq;

namespace _10._LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] poss = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] arr = new int[n];

            for (int i = 0; i < poss.Length; i++)
            {
                if (poss[i] > arr.Length - 1)
                {
                    continue;
                }
                else
                {
                    arr[poss[i]] = 1;
                }
                
            }
            //Console.WriteLine(string.Join(" ",arr));

            //string[] comArr = new string[3]; 

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] comArr = command
                    .Split()
                    .ToArray();

                int num0 = int.Parse(comArr[0]);
                int num2 = int.Parse(comArr[2]);

                if (comArr[1] == "right")
                {
                    if(arr[num0] == 1 && num0 >= 0 && num0 <= arr.Length-1)
                    {
                        if((num0+num2)>=0 && (num0 + num2) <= arr.Length-1)
                        {
                            if (arr[num0 + num2] != 1 )
                            {
                                arr[num0 + num2] = 1;
                                arr[num0] = 0;
                                continue;
                            }
                            if (arr[num0 + num2] == 1)
                            {
                                for (int i = (num0 + num2); i < arr.Length - 1; i++)
                                {
                                    if (arr[num0 + num2 + i] == 0)
                                    {
                                        arr[num0 + num2 + i] = 1;
                                        arr[num0] = 0;
                                        continue;
                                    }

                                    

                                }
                                arr[num0] = 0;

                            }
                        }
                        else
                        {
                            arr[num0] = 0;
                            continue;
                        }
                    }
                    if (arr[num0]==0)
                    {
                        continue;
                    }
                    if (num0 < 0 && num0 > arr.Length - 1)
                    {
                        continue;
                    }
                }

                if (comArr[1] == "left")
                {
                    if (arr[num0] == 1 && num0 >= 0 && num0 <= arr.Length - 1)
                    {
                        if ((num0 - num2) >= 0 && (num0 - num2) <= arr.Length - 1)
                        {
                            if (arr[num0 - num2] != 1)
                            {
                                arr[num0 - num2] = 1;
                                arr[num0] = 0;
                                continue;
                            }
                            if (arr[num0 - num2] == 1)
                            {
                                for (int i = arr.Length - 1; i > (num0 - num2); i--)
                                {
                                    if (arr[num0 - num2 - i] == 0)
                                    {
                                        arr[num0 - num2 - i] = 1;
                                        arr[num0] = 0;
                                        continue;
                                    }



                                }
                                arr[num0] = 0;

                            }
                        }
                        else
                        {
                            arr[num0] = 0;
                            continue;
                        }
                    }
                    if (arr[num0] == 0)
                    {
                        continue;
                    }
                    if (num0 < 0 && num0 > arr.Length - 1)
                    {
                        continue;
                    }
                }

            }

            if(command == "end")
            {
                Console.WriteLine(string.Join(" ",arr));
            }


        }
    }
}
