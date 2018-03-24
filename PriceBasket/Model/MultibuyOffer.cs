using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceBasket.Model
{
    class MultibuyOffer : ISpecialOffer
    {
        private string _reqProductName;
        private int _reqProductCount;
        private string _offerProductName;
        private decimal _offerProductCount;

        public MultibuyOffer(string requiredProductName, int requiredProductCount, string offerProductName, decimal offerProductCount)
        {
            _reqProductName = requiredProductName;
            _reqProductCount = requiredProductCount;
            _offerProductName = offerProductName;
            _offerProductCount = offerProductCount;

        }

        public Product DetermineSpecialOffer(IEnumerable<Product> _products)
        {
            //first, check there are both products involved in the offer in products
            if (_products.Select(p => p.ProductName).Distinct().Intersect(new string[]{ _reqProductName, _offerProductName}).Count() == 2)
            {
                //we have both items in the basket, so determine the maximum offers we can get
                var numReqProducts = _products.Where(p => p.ProductName == _reqProductName).Count();
                var numOfferProducts = _products.Where(p => p.ProductName == _offerProductName).Count();
                var offeredProductPrice = _products.Where(p => p.ProductName == _offerProductName).First().Price;

                var maxNumOffers = numReqProducts / _reqProductCount;
                //number of offers applied is the MIN of either the offerCount or the number of offerItems
                var numOfferProductsToDiscount = Math.Min(maxNumOffers * _offerProductCount, numOfferProducts);
                //if we have any products to discount, then return a product of their value
                if (numOfferProductsToDiscount > 0)
                {
                    return new Product($"{numOfferProductsToDiscount} {_offerProductName} free", -1 * numOfferProductsToDiscount * offeredProductPrice);
                }
            }
            //both Productnames aren't in the list, so no offer to be had
            return null;
        }
    }
}
