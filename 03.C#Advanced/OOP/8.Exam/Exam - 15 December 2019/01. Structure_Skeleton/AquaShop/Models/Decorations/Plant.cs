using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Decorations
{
    public class Plant : Decoration
    {
        private const decimal InitialPrice = 10.0m;
        private const int InitialComfort = 5;

        public Plant()
            : base(InitialComfort, InitialPrice)
        {
        }
    }
}
