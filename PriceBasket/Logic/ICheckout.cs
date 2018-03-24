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

        decimal DetermineTotal();
    }
}
