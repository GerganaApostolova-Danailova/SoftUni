using System;

namespace _02._Exam_Preparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int fildGrades = int.Parse(Console.ReadLine());

            int countFiledGrades = 0;

            bool isFaild = false;

            double sumOfGrades = 0;

            int count = 0;

            string nameOfProblem = string.Empty;

            string lastProblem = string.Empty;

            while ((nameOfProblem = Console.ReadLine()) != "Enough")
            {
                int grade = int.Parse(Console.ReadLine());

                if (grade <= 4)
                {
                    countFiledGrades++;

                    if (countFiledGrades == fildGrades)
                    {
                        isFaild = true;
                        break;
                    }
                }

                lastProblem = nameOfProblem;

                sumOfGrades += grade;
                count++;
            }

            if (!isFaild)
            {
                double averageScore = sumOfGrades / count;

                Console.WriteLine($"Average score: {averageScore:F2}");
                Console.WriteLine($"Number of problems: {count}");
                Console.WriteLine($"Last problem: {lastProblem}");
            }
            else
            {
                Console.WriteLine($"You need a break, {fildGrades} poor grades.");
            }
        }
    }
}
