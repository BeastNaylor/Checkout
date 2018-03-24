using PriceBasket;
using PriceBasket.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceBasketTests
{
    class FakeProductLoader : IProductLoader
    {
        public ICollection<Product> LoadProducts()
        {
            return new List<Product>() { new Product("Milk", 0.5m), new Product("Eggs", 0.8m) };
        }
    }
}
