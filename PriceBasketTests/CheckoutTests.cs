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
        [ExpectedException(typeof(InvalidOperationException), "No offers have been processed.")]
        public void CheckingOffersBeforeOffersLoaded()
        {
            var checkout = new Checkout(_products);
            //discount offer on Beans
            checkout.GetSpecialOffers();
        }

        [TestMethod]
        public void CheckOfferApplies()
        {
            var checkout = new Checkout(_products);
            //discount offer on Beans
            IEnumerable<ISpecialOffer> beansDiscount = new List<ISpecialOffer>() { new DiscountOffer("Beans", 0.1m) };
            checkout.ProcessSpecialOffers(beansDiscount);
            var offers = checkout.GetSpecialOffers().ToList();
            Assert.AreEqual(offers.Count, 1);
        }

        [TestMethod]
        public void CheckTotalAfterSpecialOffers()
        {
            var checkout = new Checkout(_products);
            //discount offer on Beans
            IEnumerable<ISpecialOffer> beansDiscount = new List<ISpecialOffer>() { new DiscountOffer("Beans", 0.1m) };
            checkout.ProcessSpecialOffers(beansDiscount);
            var total = checkout.DetermineTotal();
            //beans are 90p, eggs are 30p. 10% off beans means they are now 81, so expecting 111p
            Assert.AreEqual(total, 1.11m);
        }
    }
}
