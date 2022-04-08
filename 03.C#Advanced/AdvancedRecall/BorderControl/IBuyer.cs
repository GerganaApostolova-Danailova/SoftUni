using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public interface IBuyer
    {
        string Name { get; }
        public int Food { get; }

        void BuyFood();
    }
}
