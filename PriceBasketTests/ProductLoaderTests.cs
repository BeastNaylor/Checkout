using System;
using PriceBasket;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PriceBasketTests
{
    [TestClass]
    public class ProductLoaderTests
    {
        [TestMethod]
        public void CheckNumberOfProductsLoaded()
        {
            var loader = new ProductLoader();
            var products = loader.LoadProducts();
            Assert.AreEqual<int>(4, products.Count);
        }
    }
}
