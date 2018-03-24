using PriceBasket.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceBasket.Logic
{
    class Checkout : ICheckout
    {
        private IEnumerable<Product> _loadedProducts;

        public Checkout(IEnumerable<Product> products)
        {
            _loadedProducts = products;
        }

        public decimal DetermineSubtotal()
        {
            return _loadedProducts.Sum(p => p.Price);
        }

        public decimal DetermineTotal()
        {
            throw new NotImplementedException();
        }
    }
}
