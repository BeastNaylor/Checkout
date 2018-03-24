using PriceBasket.Logic;
using PriceBasket.Model;
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
            var checkout = new Checkout(validator.GetValidatedProducts());
            Console.WriteLine($"Subtotal: {string.Format("{0:C}", checkout.DetermineSubtotal())}");
            //load the special offers
            var specialOffers = new SpecialOfferLoader(DateTime.Today.AddDays(3)).LoadCurrentOffers();
            checkout.ProcessSpecialOffers(specialOffers);
            if (checkout.GetSpecialOffers().Any())
            {
                foreach (Product offer in checkout.GetSpecialOffers())
                {
                    Console.WriteLine($"{ offer.ProductName}: {string.Format("{0:C}", offer.Price)}");
                }
            } else
            {
                Console.WriteLine("(No offers available)");
            }
            Console.WriteLine($"Total: {string.Format("{0:C}", checkout.DetermineTotal())}");
        }
    }
}
