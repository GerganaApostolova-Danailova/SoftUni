using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double lenght;
        private double widht;
        private double height;

        public Box(double lenght, double width, double height)
        {
            Lenght = lenght;
            Width = width;
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

        public double Width
        {
            get
            {
                return widht;
            }
            set
            {
                ValidateData(value, "Width cannot be zero or negative.");

                //if (value > 0)
                //{
                    widht = value;
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
            return 2 * this.Lenght * this.Width + 2 * this.Lenght * this.Height
                + 2 * this.Width * this.Height;
        }

        public double GetLateralSurfaceArea()
        {
            return 2 * this.Lenght * this.Height
                + 2 * this.Width * this.Height;
        }

        public double GetVolume()
        {
            return this.Lenght * this.Height * this.Width;
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
