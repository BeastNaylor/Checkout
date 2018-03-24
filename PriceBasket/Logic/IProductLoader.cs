using System;
using PriceBasket.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceBasket.Logic
{
    interface IProductLoader
    {
        ICollection<Product> LoadProducts();
    }
}
