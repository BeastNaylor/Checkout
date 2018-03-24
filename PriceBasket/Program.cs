using PriceBasket.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceBasket
{
    class Program
    {
        static void Main(string[] args)
        {
            //load the Products
            var products = new ProductLoader().LoadProducts();

            //take the arguments and put them through the validator to make sure they are all valid items
            IInputValidator validator = new InputValidator(products);
            if (!validator.ValidateInput(args))
            {
                //TODO: could return which of the inputs were invalid
                Console.WriteLine("Invalid input received.");
                return;
            }
            //pass the newly validated products into the checkout to determine the subtotal
            
            
        }
    }
}
