using System;
using System.Collections.Generic;
using System.Linq;

namespace Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string command = Console.ReadLine();

            while (true)
            {
                if (command == "End")
                {
                    break;
                }

                string[] currant = command.Split().ToArray();

                if (currant[0] == "Complete")
                {
                    int index = int.Parse(currant[1]);

                    if (index >= 0 && index < list.Count)
                    {
                        if (index == list.Count - 1)
                        {
                            list.RemoveAt(index);
                            list.Add(0);
                        }
                        else
                        {
                            list.Insert(index, 0);
                            list.RemoveAt(index + 1);
                        }
                    }
                }
                else if (currant[0] == "Change")
                {
                    int index = int.Parse(currant[1]);
                    int time = int.Parse(currant[2]);

                    if (index >= 0 && index < list.Count)
                    {
                        if (index == list.Count - 1)
                        {
                            list.RemoveAt(index);
                            list.Add(time);
                        }
                        else
                        {
                            list.Insert(index, time);
                            list.RemoveAt(index + 1);
                        }
                    }

                }
                else if (currant[0] == "Drop")
                {
                    int index = int.Parse(currant[1]);

                    if (index >= 0 && index < list.Count)
                    {
                        if (index == list.Count - 1)
                        {
                            list.RemoveAt(index);
                            list.Add(-1);
                        }
                        else
                        {
                            list.Insert(index, -1);
                            list.RemoveAt(index + 1);
                        }
                    }

                }
                else if (currant[0] == "Count" && currant[1] == "Dropped")
                {
                    int cout = 0;

                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i] < 0)
                        {
                            cout++;
                        }
                    }
                   
                    Console.WriteLine($"{cout}");
                }
                else if (currant[0] == "Count" && currant[1] == "Completed")
                {
                    int cout = 0;

                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i] == 0)
                        {
                            cout++;
                        }
                    }
                   
                    Console.WriteLine($"{cout}");
                }
                else if (currant[0] == "Count" && currant[1] == "Incomplete")
                {
                    int cout = 0;

                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i] > 0)
                        {
                            cout++;
                        }
                    }
                    
                    Console.WriteLine($"{cout}");
                }

                command = Console.ReadLine();

            }
          

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] > 0)
                {
                    Console.Write(list[i] + " ");
                }
            }
            
        }
    }
}
