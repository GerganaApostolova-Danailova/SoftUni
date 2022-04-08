using System;
using System.Collections.Generic;
using System.Text;

namespace _02PointInRectangle
{
    public class Point
    {
        public Point(int cordinateX, int cordinateY)
        {
            CordinateX = cordinateX;
            CordinateY = cordinateY;
        }

        public int CordinateX { get; set; }
        public int CordinateY { get; set; }


    }
}
