using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise4
{
    public class Product
    {
        public string Name { get; private set; }
        public int Quantity { get; private set; }

        public Product(string name)
        {
            Name = name;
            Quantity = 1;
        }

        public void IncreaseProductQuantity(int amount)
        {
            this.Quantity += amount;
        }
    }
}
