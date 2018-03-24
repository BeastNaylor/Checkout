using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PriceBasket.Model;

namespace PriceBasketTests
{
    [TestClass]
    public class MultibuyOfferTests
    {
        ICollection<Product> _products;

        [TestInitialize]
        public void Init()
        {
            _products = new List<Product>() { new Product("Beans", 0.9m), new Product("Eggs", 0.3m) };
        }

        [TestMethod]
        public void MultibuyNoRelatedProducts()
        {
            //no products involved in the deal in the list
            ISpecialOffer offer = new MultibuyOffer("Soup", 2, "Milk", 1);
            var discountProduct = offer.DetermineSpecialOffer(_products);
            Assert.IsNull(discountProduct);
        }

        [TestMethod]
        public void MultibuyOnlyOneRelatedProducts()
        {
            ISpecialOffer offer = new MultibuyOffer("Beans", 2, "Soup", 1);
            var discountProduct = offer.DetermineSpecialOffer(_products);
            Assert.IsNull(discountProduct);
        }

        [TestMethod]
        public void MultibuyBothRelatedProductsNotEnoughRequired()
        {
            //need two beans to get the offer, so shouldn't give an offer
            ISpecialOffer offer = new MultibuyOffer("Beans", 2, "Eggs", 1);
            var discountProduct = offer.DetermineSpecialOffer(_products);
            Assert.IsNull(discountProduct);
        }

        [TestMethod]
        public void MultibuyBothRelatedProductsMoreOfferThanPresent()
        {
            //have two beans, could get two eggs discounted, but only one egg is present
            //thus only one egg is discounted
            var _twoBeansOneEggs = new List<Product>() { new Product("Beans", 0.9m), new Product("Beans", 0.9m), new Product("Eggs", 0.3m) };
            ISpecialOffer offer = new MultibuyOffer("Beans", 2, "Eggs", 2);
            var discountProduct = offer.DetermineSpecialOffer(_twoBeansOneEggs);
            Assert.AreEqual<decimal>(-0.3m, discountProduct.Price);
        }

        [TestMethod]
        public void MultibuyBothRelatedProductsMorePresentThanOffer()
        {
            //have two beans, can get one egg discounted even though two eggs are present
            var _twoBeansTwoEggs = new List<Product>() { new Product("Beans", 0.9m), new Product("Beans", 0.9m), new Product("Eggs", 0.3m), new Product("Eggs", 0.3m) };
            ISpecialOffer offer = new MultibuyOffer("Beans", 2, "Eggs", 1);
            var discountProduct = offer.DetermineSpecialOffer(_twoBeansTwoEggs);
            Assert.AreEqual<decimal>(-0.3m, discountProduct.Price);
        }

        [TestMethod]
        public void MultibuyBothRelatedProductsMultipleProductsOffer ()
        {
            //have two beans, can get two eggs discounted, two eggs are present so should get two eggs discounted
            var _twoBeansTwoEggs = new List<Product>() { new Product("Beans", 0.9m), new Product("Beans", 0.9m), new Product("Eggs", 0.3m), new Product("Eggs", 0.3m) };
            ISpecialOffer offer = new MultibuyOffer("Beans", 2, "Eggs", 2);
            var discountProduct = offer.DetermineSpecialOffer(_twoBeansTwoEggs);
            Assert.AreEqual<decimal>(-0.6m, discountProduct.Price);
        }

    }
}
