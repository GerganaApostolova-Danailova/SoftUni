using System;
using System.Linq;

namespace _02PointInRectangle
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int[] points = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int numberOfPoints = int.Parse(Console.ReadLine());

            Point topLeft = new Point(points[0], points[1]);
            Point bottemRight = new Point(points[2], points[3]);

            Rectangle rectangle = new Rectangle(topLeft, bottemRight);

            for (int i = 0; i < numberOfPoints; i++)
            {
                int[] currentPoint = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

                Point point = new Point(currentPoint[0], currentPoint[1]);

                Console.WriteLine(rectangle.Contains(point));
            }
        }
    }
}
