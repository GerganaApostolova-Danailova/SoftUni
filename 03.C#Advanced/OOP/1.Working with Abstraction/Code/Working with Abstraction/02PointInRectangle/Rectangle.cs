using System;
using System.Collections.Generic;
using System.Text;

namespace _02PointInRectangle
{
    class Rectangle
    {
        public Rectangle(Point topLeft, Point bottomRight)
        {
            TopLeft = topLeft;
            BottomRight = bottomRight;
        }

        public Point TopLeft { get; set; }
        public Point BottomRight { get; set; }

        public bool Contains (Point point)
        {
            bool insydeByX = point.CordinateX >= TopLeft.CordinateX 
                && point.CordinateX <= BottomRight.CordinateX;

            bool insydeByY = point.CordinateY >= TopLeft.CordinateY
                && point.CordinateY <= BottomRight.CordinateY;

            bool isInsidePoint = insydeByX && insydeByY;

            return isInsidePoint;

        }
    }
}
