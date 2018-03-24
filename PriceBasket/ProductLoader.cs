using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceBasket
{
    class ProductLoader : IProductLoader
    {
        public ICollection<Product> LoadProducts()
        {
            //load each of the Products and their prices.
            //TODO: move this function out of the code so Products can be dynamically added
            var products = new List<Product>();
            products.Add(new Product("Soup", 0.65m));
            products.Add(new Product("Bread", 0.80m));
            products.Add(new Product("Milk", 1.30m));
            products.Add(new Product("Apples", 1.00m));
            return products;
        }
    }
}
