using System;

namespace _02._Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            double grade = double.Parse(Console.ReadLine());

            string finalGrade = PrintGrade(grade);

            Console.WriteLine(finalGrade);
        }

        static string PrintGrade(double num)
        {
            string final = " ";

            if (num >= 2.00 && num <= 2.99)
            {

                final = "Fail";
            }
            else if (num >= 3.00 && num <= 3.49)
            {

                final = "Poor";
            }
            else if (num >= 3.50 && num <= 4.49)
            {

                final = "Good";
            }
            else if (num >= 4.50 && num <= 5.49)
            {

                final = "Very good";
            }
            else if (num >= 5.50 && num <= 6.00)
            {

                final = "Excellent";
            }

            return final;
        }
    }
}
