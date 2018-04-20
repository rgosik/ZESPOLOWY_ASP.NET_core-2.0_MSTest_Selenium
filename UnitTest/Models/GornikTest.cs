using AspCoreApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UnitTest
{
    [TestClass]
    public class GornikTest
    {
        string firstName;
        string lastName;

        [TestInitialize]
        public void InitializeTests()
        {
            firstName = "Jack";
            lastName = "Sketch";
        }

        [TestMethod]
        public void GornikDataIsValidTest()
        {
            var miner = new Gornik()
            {
                FirstName = firstName,
                LastName = lastName,
            };
            var context = new ValidationContext(miner);
            var result = new List<ValidationResult>();
            var val = Validator.TryValidateObject(miner, context, result, true);
            Assert.IsTrue(val);
        }
        [TestMethod]
        public void GornikDataIsShortTest()
        {
            var miner = new Gornik()
            {
                FirstName = "f",
                LastName = "g",
            };
            var context = new ValidationContext(miner);
            var result = new List<ValidationResult>();
            var val = Validator.TryValidateObject(miner, context, result, false);
            Assert.IsTrue(val);
        }
        [TestMethod]
        public void GornikDataIsNotValidTest()
        {
            var miner = new Gornik()
            {
                FirstName = "f533cf",
                LastName = "g5325f",
            };
            var context = new ValidationContext(miner);
            var result = new List<ValidationResult>();
            var val = Validator.TryValidateObject(miner, context, result, false);
            Assert.IsTrue(val);
        }
    }
}
