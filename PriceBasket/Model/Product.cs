using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceBasket.Model
{
    public class Product
    {
        public readonly string ProductName;
        public readonly decimal Price;

        public Product(string productName, decimal price)
        {
            ProductName = productName;
            Price = price;    
        }
    }
}
