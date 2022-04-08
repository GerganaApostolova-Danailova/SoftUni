using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Food
{
    public abstract class Food
    {
        private int quantity;

        protected Food(int quantity)
        {
            Quantity = quantity;
        }

        public int Quantity
        {
            get { return quantity; }
            private set { quantity = value; }
        }
    }
}
