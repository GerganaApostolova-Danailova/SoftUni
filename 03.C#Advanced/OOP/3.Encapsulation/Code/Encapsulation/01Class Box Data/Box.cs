using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double lenght;
        private double width;
        private double height;

        public Box(double lenght, double wight, double height)
        {
            Lenght = lenght;
            Wight = wight;
            Height = height;
        }

        public double Lenght
        {
            get
            {
                return lenght;
            }
            set
            {
                ValidateData(value, "Length cannot be zero or negative.");
                //if (value > 0)
                //{
                lenght = value;
                //}
                //else
                //{
                //    throw new ArgumentException("Lenght cannot be zero or negative.");
                //}

            }
        }

        public double Wight
        {
            get
            {
                return width;
            }
            set
            {
                ValidateData(value, "Wight cannot be zero or negative.");

                //if (value > 0)
                //{
                    width = value;
                //}
                //else
                //{
                //    throw new ArgumentException("Width cannot be zero or negative.");
                //}
            }
        }

        public double Height
        {
            get
            {
                return height;
            }
            set
            {
                ValidateData(value, "Height cannot be zero or negative.");

                //if (value > 0)
                //{
                height = value;
                //}
                //else
                //{
                //    throw new ArgumentException("Height cannot be zero or negative.");
                //}
            }
        }

        public double GetSurfaceArea()
        {
            return 2 * this.Lenght * this.Wight + 2 * this.Lenght * this.Height
                + 2 * this.Wight * this.Height;
        }

        public double GetLateralSurfaceArea()
        {
            return 2 * this.Lenght * this.Height
                + 2 * this.Wight * this.Height;
        }

        public double GetVolume()
        {
            return this.Lenght * this.Height * this.Wight;
        }

        private static void ValidateData(double value, string message)
        {
            if (value <= 0)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
