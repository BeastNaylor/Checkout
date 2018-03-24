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
        private ICollection<Product> _applicableSpecialOffers;
        private bool _offersBeenProcessed;

        public Checkout(IEnumerable<Product> products)
        {
            _loadedProducts = products;
        }

        public decimal DetermineSubtotal()
        {
            return _loadedProducts.Sum(p => p.Price);
        }

        public decimal DetermineSpecialOffersSavings()
        {
            return _applicableSpecialOffers.Sum(p => p.Price);
        }

        public decimal DetermineTotal()
        {
            return DetermineSubtotal() + DetermineSpecialOffersSavings();
        }

        public IEnumerable<Product> GetSpecialOffers()
        {
            //if we haven't processed the offers, throw an exception
            if (!_offersBeenProcessed) { throw new InvalidOperationException("No offers have been processed."); }
            return _applicableSpecialOffers;
        }

        public void ProcessSpecialOffers(IEnumerable<ISpecialOffer> offers)
        {
            _applicableSpecialOffers = new List<Product>();
            foreach (ISpecialOffer offer in offers)
            {
                var discountProduct = offer.DetermineSpecialOffer(_loadedProducts);
                if (discountProduct != null)
                {
                    _applicableSpecialOffers.Add(discountProduct);
                }
            }
            _offersBeenProcessed = true;
        }
    }
}
