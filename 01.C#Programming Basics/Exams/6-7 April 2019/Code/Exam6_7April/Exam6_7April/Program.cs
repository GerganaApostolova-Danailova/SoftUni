using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam6_7April
{
    class Program
    {
        static void Main(string[] args)
        {
            int NumberOfFilm = int.Parse(Console.ReadLine());
            double maxRating = double.MinValue;
            double minRating = double.MaxValue;
            string maxRatingFilm = string.Empty;
            string minRatingFilm = string.Empty;
            double sumRating = 0;
            double middleRating = 0;

            for (int i = 0; i< NumberOfFilm; i++)
            {
                string NameOfTheFilm = Console.ReadLine();
                double rating = double.Parse(Console.ReadLine());
                sumRating += rating;

                if ( rating > maxRating)
                {
                    maxRating = rating;
                    maxRatingFilm = NameOfTheFilm;
                }
                else if ( rating < minRating)
                {
                    minRating = rating;
                    minRatingFilm = NameOfTheFilm;
                }
              
            }

            middleRating = sumRating / NumberOfFilm;
            Console.WriteLine($"{maxRatingFilm} is with highest rating: {maxRating:f1}");
            Console.WriteLine($"{minRatingFilm} is with lowest rating: {minRating:f1}");
            Console.WriteLine($"Average rating: {middleRating:f1}");
        }
    }
}
