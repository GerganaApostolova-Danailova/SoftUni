
namespace DefiningClasses
{
    public class Tire
    {
        private double tirePressure;
        private int year;

        public Tire(double tirePressur, int year)
        {
            TirePressur = tirePressur;
            Year = year;
        }

        public double TirePressur
        {
            get { return tirePressure; }
            set { tirePressure = value; }
        }

        public int Year
        {
            get { return year; }
            set { year = value; }
        }



    }
}

