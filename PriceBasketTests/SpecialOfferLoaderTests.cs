using System;
using PriceBasket.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PriceBasketTests
{
    [TestClass]
    public class SpecialOfferLoaderTests
    {
        [TestMethod]
        public void CheckNumberOfOffersLoadedLastYear()
        {
            var lastYear = new DateTime(2017, 3, 25);
            var loader = new SpecialOfferLoader(lastYear);
            var products = loader.LoadCurrentOffers();
            Assert.AreEqual<int>(0, products.Count);
        }

        [TestMethod]
        public void CheckNumberOfOffersLoadedFor28thApril2018()
        {
            var thisYear = new DateTime(2018, 3, 25);
            var loader = new SpecialOfferLoader(thisYear);
            var products = loader.LoadCurrentOffers();
            Assert.AreEqual<int>(2, products.Count);
        }
    }
}
