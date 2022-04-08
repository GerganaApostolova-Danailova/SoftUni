using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : IDrawebel
    {
        private int width;
        private int height;

        public Rectangle(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public void Draw()
        {
            DrawLine('*', '*');

            for (int i = 1; i < height - 1; ++i)
            {
                DrawLine('*', ' ');
            }

            DrawLine('*', '*');
        }

        private void DrawLine(char borderSymbol, char innerSymbol)
        {
            Console.Write(borderSymbol);

            for (int i = 1; i < width - 1; ++i)
            {
                Console.Write(innerSymbol);
            }

            Console.WriteLine(borderSymbol);
        }
    }
}
