using AspCoreApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UnitTest
{
    [TestClass]
    public class KluczTest
    {
        string name;
        int type;

        [TestInitialize]
        public void InitializeTests()
        {
            name = "boss";
            type = 7;
        }

        [TestMethod]
        public void KluczDataIsValidTest()
        {
            var key = new Klucz()
            {
                Name = name,
                Type = type,
            };
            var context = new ValidationContext(key);
            var result = new List<ValidationResult>();
            var val = Validator.TryValidateObject(key, context, result, true);
            Assert.IsTrue(val);
        }
        [TestMethod]
        public void KluczDataIsNotValidTest()
        {
            var key = new Klucz()
            {
                Name = "f",
                Type = -11,
            };
            var context = new ValidationContext(key);
            var result = new List<ValidationResult>();
            var val = Validator.TryValidateObject(key, context, result, false);
            Assert.IsTrue(val);
        }
    }
}
