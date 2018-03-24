using PriceBasket.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceBasket.Logic
{
    interface ICheckout
    {
        decimal DetermineSubtotal();

        void ProcessSpecialOffers(IEnumerable<ISpecialOffer> products);

        IEnumerable<Product> GetSpecialOffers();

        decimal DetermineTotal();
    }
}
