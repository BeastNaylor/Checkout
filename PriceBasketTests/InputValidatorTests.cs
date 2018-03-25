using System;
using System.Collections.Generic;
using PriceBasket.Logic;
using PriceBasket.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PriceBasketTests
{
    [TestClass]
    public class InputValidatorTests
    {
        IEnumerable<Product> _products;

        [TestInitialize]
        public void Init()
        {
            _products = new FakeProductLoader().LoadProducts();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "No products have been loaded.")]
        public void GetItemsBeforeValidating()
        {
            var input = new string[] { "Milk", "Eggs" };
            var validator = new InputValidator(_products);
            validator.GetValidatedProducts();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "No products have been loaded.")]
        public void GetItemsAfterFailedValidate()
        {
            var input = new string[] { "Beans" };
            var validator = new InputValidator(_products);
            validator.ValidateInput(input);
            validator.GetValidatedProducts();
        }

        [TestMethod]
        public void CheckMilkAndEggsValid()
        {
            var input = new string[] { "Milk", "Eggs" };
            var validator = new InputValidator(_products);
            var isValidProducts = validator.ValidateInput(input);
            Assert.IsTrue(isValidProducts);
        }

        [TestMethod]
        public void CheckBeansNotValid()
        {
            var input = new string[] { "Beans" };
            var validator = new InputValidator(_products);
            var isValidProducts = validator.ValidateInput(input);
            Assert.IsFalse(isValidProducts);
        }

        [TestMethod]
        public void CheckWrongCaseValid()
        {
            var input = new string[] { "milk", "EGGS" };
            var validator = new InputValidator(_products);
            var isValidProducts = validator.ValidateInput(input);
            Assert.IsTrue(isValidProducts);
        }
    }
}
