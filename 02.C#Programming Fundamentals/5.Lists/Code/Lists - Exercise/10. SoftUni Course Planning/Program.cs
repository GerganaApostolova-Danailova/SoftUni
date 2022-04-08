using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._SoftUni_Course_Planning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                .Split(", ")
                .ToList();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "course start")
                {
                    break;
                }

                string[] currentInput = command.Split(":");

                if (currentInput[0] == "Add")
                {
                    bool isExist = false;

                    for (int i = 0; i < input.Count; i++)
                    {
                        if (input[i] != currentInput[1])
                        {
                            isExist = true;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (isExist)
                    {
                        input.Add(currentInput[1]);
                    }

                }
                else if (currentInput[0] == "Remove")
                {
                    for (int i = 0; i < input.Count; i++)
                    {
                        string leson = currentInput[1];
                        string lesonWithExercise = leson + "-Exercise";
                        if (input[i] == leson)
                        {
                            if (input.Contains(lesonWithExercise))
                            {
                                input.Remove(lesonWithExercise);
                            }
                            input.Remove(leson);
                            break;

                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                else if (currentInput[0] == "Swap")
                {
                    string lesonOne = currentInput[1];
                    string lesonOneExercise = lesonOne + "-Exercise";

                    string lesonTwo = currentInput[2];
                    string lesonTwoExercise = lesonTwo + "-Exercise";

                    if (input.Contains(lesonOne) && input.Contains(lesonTwo))
                    {
                        int index1 = input.IndexOf(lesonOne);
                        int index2 = input.IndexOf(lesonTwo);

                        string temp = lesonOne;

                        input.RemoveAt(index1);
                        input.Insert(index1, lesonTwo);
                        input.RemoveAt(index2);
                        input.Insert(index2, temp);

                       
                        if (input.Contains(lesonOneExercise))
                        {
                            input.Remove(lesonOneExercise);
                            input.Insert(index2 + 1, lesonOneExercise);
                        }
                        if (input.Contains(lesonTwoExercise))
                        {
                            input.Remove(lesonTwoExercise);
                            input.Insert(index1 + 1, lesonTwoExercise);
                        }
                    }
                }
                else if (currentInput[0] == "Insert")
                {
                    bool isExist = false;

                    for (int i = 0; i < input.Count; i++)
                    {
                        if (input[i] != currentInput[1])
                        {
                            isExist = true;
                        }
                        else
                        {
                            isExist = false;
                            break;
                        }
                    }
                    if (isExist)
                    {
                        int positionToInsert = int.Parse(currentInput[2]);
                        input.Insert(positionToInsert, currentInput[1]);
                    }
                }
                else if (currentInput[0] == "Exercise")
                {

                    string title = currentInput[1];

                    if (input.Contains(title))
                    {
                        int index = input.IndexOf(title);

                        if (index + 1 < input.Count)
                        {
                            if (input[index + 1] != $"{title}-Exercise")
                            {
                                input.Insert(index + 1, $"{title}-Exercise");
                            }
                        }
                        else
                        {
                            input.Add($"{title}-Exercise");
                        }
                    }
                    else
                    {
                        input.Add(title);
                        input.Add($"{title}-Exercise");
                    }
                }

            }
            for (int i = 1; i <= input.Count; i++)
            {
                Console.WriteLine($"{i}.{input[i - 1]}");
            }
        }
    }
}
