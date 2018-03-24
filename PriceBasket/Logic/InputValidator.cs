using System;
using PriceBasket.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceBasket.Logic
{
    class InputValidator : IInputValidator
    {
        private IEnumerable<Product> _validProducts;
        private ICollection<Product> _inputProducts;
        private bool _hasBeenValidated;

        public InputValidator(IEnumerable<Product> validProducts)
        {
            _validProducts = validProducts;
        }

        public ICollection<Product> GetValidatedProducts()
        {
            //if we haven't Validated any input successfully, throw an exception
            if (!_hasBeenValidated) { throw new InvalidOperationException("No products have been loaded."); }
            return _inputProducts;
        }

        public bool ValidateInput(IEnumerable<string> input)
        {
            _inputProducts = new List<Product>();
            //compare the input we have received with the validProducts
            foreach (string inputItem in input)
            {
                var product = _validProducts.Where(p => p.ProductName == inputItem).SingleOrDefault();
                if (product != null)
                {
                    _inputProducts.Add(product);
                }
                else
                {
                    //once we find a bad input, no point in continuing, so return
                    return false;
                }
            }
            //mark we have some validatedProducts to process
            _hasBeenValidated = true;
            return true;
        }
    }
}
