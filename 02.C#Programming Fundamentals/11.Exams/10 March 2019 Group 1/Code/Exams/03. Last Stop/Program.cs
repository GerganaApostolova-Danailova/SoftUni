using System;
using System.Collections.Generic;
using System.Linq;

namespace Last_Stop
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
                if (command == "END")
                {
                    break;
                }

                string[] currunt = command.Split().ToArray();

                if (currunt[0] == "Change")
                {
                    int paintingNumber = int.Parse(currunt[1]);
                    int changedNumber = int.Parse(currunt[2]);

                    if (list.Contains(paintingNumber))
                    {
                        int index = list.IndexOf(paintingNumber);
                        list.Insert(index, changedNumber);
                        list.Remove(paintingNumber);
                    }
                }
                else if (currunt[0] == "Hide")
                {
                    int paintingNumber = int.Parse(currunt[1]);

                    if (list.Contains(paintingNumber))
                    {
                        list.Remove(paintingNumber);
                    }
                }
                else if (currunt[0] == "Switch")
                {
                    int paintingNumber1 = int.Parse(currunt[1]);
                    int paintingNumber2 = int.Parse(currunt[2]);

                    if (list.Contains(paintingNumber1) && list.Contains(paintingNumber2))
                    {
                        int index1 = list.IndexOf(paintingNumber1);
                        int index2 = list.IndexOf(paintingNumber2);

                        int temp = paintingNumber1;

                        list.RemoveAt(index1);
                        list.Insert(index1, paintingNumber2);
                        list.RemoveAt(index2);
                        list.Insert(index2, temp);
                    }
                }
                else if (currunt[0] == "Insert")
                {
                    int place = int.Parse(currunt[1]);
                    int paintingNumber = int.Parse(currunt[2]);

                    if (place + 1 < list.Count)
                    {
                        list.Insert(place + 1, paintingNumber);
                    }
                }
                else if (currunt[0] == "Reverse")
                {
                    list.Reverse();

                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", list));
        }
    }
}
