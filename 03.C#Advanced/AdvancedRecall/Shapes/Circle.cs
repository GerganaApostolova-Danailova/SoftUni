using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : IDrawable
    {
        public int Radius { get; set; }
        public void Draw()
        {
            throw new NotImplementedException();
        }
    }
}
