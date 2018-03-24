using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceBasket.Model
{
    interface ISpecialOffer
    {
        Product DetermineSpecialOffer(IEnumerable<Product> _products);
    }
}
