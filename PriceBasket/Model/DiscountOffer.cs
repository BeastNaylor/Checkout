using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceBasket.Model
{
    class DiscountOffer : ISpecialOffer
    {
        private string _productName;
        private decimal _discount;

        public DiscountOffer(string productName, decimal discount)
        {
            _productName = productName;
            _discount = discount;
        }

        public Product DetermineSpecialOffer(IEnumerable<Product> products)
        {
            //check if the products contains the item on offer.
            var discountProducts = products.Where(p => p.ProductName == _productName);
            if (discountProducts.Any())
            {
                var totalProductPrice = discountProducts.Sum(p => p.Price);
                //return an item of that is the price of the discount
                var finalDiscountValue = decimal.Round(-1 * totalProductPrice * _discount, 2);
                return new Product($"{_productName} {_discount.ToString("p0")} off", finalDiscountValue);
            }
            // if there are no items returning, we have no discount
            return null;
        }
    }
}
