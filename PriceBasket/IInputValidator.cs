using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceBasket
{
    interface IInputValidator
    {
        bool ValidateInput(IEnumerable<string> input);

        ICollection<Product> GetValidatedProducts();
    }
}
