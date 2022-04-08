using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainThe_Trainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int jury = int.Parse(Console.ReadLine());

            string name = " ";
            double sumAllPresentatio = 0;
            int counter = 0;
            int sumCounter = 0;
            double allSum = 0;

            while ( (name = Console.ReadLine()) != "Finish")
            {
                double sum = 0;
                double averageForCurrentPresentation = 0;
                string presentatioName = string.Empty;
                
               

                for (int i = 0; i < jury; i++)
                {
                    double score = double.Parse(Console.ReadLine());

                   sum += score;
                    presentatioName = name;
                    averageForCurrentPresentation = sum / jury;
                    counter++;
                   
                }
                allSum += sum;
                sumCounter += counter;
                sumAllPresentatio += averageForCurrentPresentation;
                counter = 0;
                sum = 0;

                Console.WriteLine($"{presentatioName} - {averageForCurrentPresentation:f2}.");
                
            }
            if (name == "Finish")
            {
                Console.WriteLine($"Student's final assessment is {(allSum/sumCounter):f2}.");
            }
        }
    }
}
