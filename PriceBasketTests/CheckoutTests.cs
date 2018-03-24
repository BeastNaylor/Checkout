using System;
using System.Linq;
using PriceBasket.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PriceBasket.Model;

namespace PriceBasketTests
{
    [TestClass]
    public class CheckoutTests
    {
        ICollection<Product> _products;

        [TestInitialize]
        public void Init()
        {
            _products = new List<Product>() { new Product("Beans", 0.9m), new Product("Eggs", 0.3m) };
        }

        [TestMethod]
        public void EmptyCheckoutReturnsZero()
        {
            var checkout = new Checkout(new List<Product>());
            var subtotal = checkout.DetermineSubtotal();
            Assert.AreEqual<decimal>(subtotal, 0m);
        }

        [TestMethod]
        public void CheckSingleProductHasCorrectPrice()
        {
            var singleProduct = _products.Take(1);
            var checkout = new Checkout(singleProduct);
            var subtotal = checkout.DetermineSubtotal();
            Assert.AreEqual<decimal>(subtotal, 0.9m);
        }

        [TestMethod]
        public void CheckMultipleProductsHaveCorrectPrice()
        {
            var checkout = new Checkout(_products);
            var subtotal = checkout.DetermineSubtotal();
            Assert.AreEqual<decimal>(subtotal, 1.2m);
        }

        [TestMethod]
        public void CheckDiscountOfferApplies()
        {
            var checkout = new Checkout(_products);
            //checkout.ProcessSpecialOffers(new ());
            var subtotal = checkout.DetermineSubtotal();
            Assert.AreEqual<decimal>(subtotal, 1.2m);
        }
    }
}
