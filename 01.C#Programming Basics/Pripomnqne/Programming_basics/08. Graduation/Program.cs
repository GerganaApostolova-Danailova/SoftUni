using System;

namespace _08._Graduation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();

            double sum = 0;
            int count = 0;
            double averageGrade = 0;

            int excludedCount = 0;
            bool isExcluded = false;

            while (count < 12)
            {
                double grade = double.Parse(Console.ReadLine());

                sum += grade;

                if (grade < 4)
                {
                    excludedCount++;

                    if (excludedCount == 2)
                    {
                        isExcluded = true;
                        break;
                    }
                }

                count++;
            }

            if (isExcluded == false)
            {
                averageGrade = sum / 12;
                Console.WriteLine($"{name} graduated. Average grade: {averageGrade:F2}");
            }
            else
            {
                Console.WriteLine($"{name} has been excluded at {count} grade");
            }
        }
    }
}
