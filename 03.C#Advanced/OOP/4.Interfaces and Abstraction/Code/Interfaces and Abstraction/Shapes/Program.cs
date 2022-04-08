using System;

namespace Shapes
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var radius = int.Parse(Console.ReadLine());

            IDrawebel circle = new Circle(radius);

            var width = int.Parse(Console.ReadLine());
            var height = int.Parse(Console.ReadLine());

            IDrawebel rectangle = new Rectangle(width, height);

            circle.Draw();
            rectangle.Draw();
        }
    }
}
