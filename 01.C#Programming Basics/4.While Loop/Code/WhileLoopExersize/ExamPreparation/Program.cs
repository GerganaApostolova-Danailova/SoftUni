using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int possibleBedGrades = int.Parse(Console.ReadLine());
            
            
            int bedGradescounter = 0;
            string lastcomments = string.Empty;
            int totalGradeCounter = 0;
            int gradeSum = 0;


            while ( bedGradescounter < possibleBedGrades)
            {
                string Command = Console.ReadLine();

                if (Command == "Enough")
                {
                    break;
                }

                int Currentgrade = int.Parse(Console.ReadLine());

                lastcomments = Command;
                totalGradeCounter++;
                gradeSum += Currentgrade;

                if (Currentgrade <= 4)
                {
                    bedGradescounter++;
                }

            }

            if (bedGradescounter == possibleBedGrades)
            {
                Console.WriteLine($"You need a break, {bedGradescounter} poor grades.");
            }

            else
            {
                double avg = gradeSum / (double)totalGradeCounter;
                Console.WriteLine($"Average score: {avg:f2}");
                Console.WriteLine($"Number of problems: {totalGradeCounter}");
                Console.WriteLine($"Last problem: {lastcomments}");

            }
        }
    }
}
