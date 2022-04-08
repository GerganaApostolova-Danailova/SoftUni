using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;


namespace _09._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {

            Stack<string> undoCommand = new Stack<string>();

            StringBuilder text = new StringBuilder();

            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = input[0];

                if (command == "1")
                {
                    undoCommand.Push(text.ToString());
                    text.Append(input[1]);
                }
                else if (command == "2")
                {
                    int index = int.Parse(input[1]);
                    undoCommand.Push(text.ToString());
                    text.Remove(text.Length - index, index);

                }
                else if (command == "3")
                {
                    int index = int.Parse(input[1]);

                    Console.WriteLine(text[index - 1]);

                }
                else if (command == "4")
                {
                    text.Clear();
                    text.Append(undoCommand.Pop());

                }
            }
        }
    }
}

