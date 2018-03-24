using System;
using System.Linq;
using PriceBasket.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PriceBasket.Model;

namespace PriceBasketTests
{
    [TestClass]
    public class DiscountOfferTests
    {
        ICollection<Product> _products;

        [TestInitialize]
        public void Init()
        {
            _products = new List<Product>() { new Product("Beans", 0.9m), new Product("Eggs", 0.3m) };
        }

        [TestMethod]
        public void CheckNoDiscountProducts()
        {
            var offer = new DiscountOffer("Soup", 0.3m);
            var discountProduct = offer.DetermineSpecialOffer(_products);
            Assert.IsNull(discountProduct);
        }

        [TestMethod]
        public void CheckEggDiscount()
        {
            var offer = new DiscountOffer("Eggs", 0.1m);
            var discountProduct = offer.DetermineSpecialOffer(_products);
            //expecting 10% off the price of Eggs (30p), so discountProduct should be 3p
            Assert.AreEqual("Eggs 10% off", discountProduct.ProductName);
            Assert.AreEqual(0.03m, discountProduct.Price);
        }
    }
}
