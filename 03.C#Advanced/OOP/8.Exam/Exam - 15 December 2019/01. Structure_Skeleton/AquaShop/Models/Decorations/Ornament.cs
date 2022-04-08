using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Decorations
{
    public class Ornament : Decoration
    {
        private const decimal InitialPrice = 5.0m;
        private const int InitialComfort = 1;

        public Ornament()
            : base(InitialComfort, InitialPrice)
        {
        }
    }
}
