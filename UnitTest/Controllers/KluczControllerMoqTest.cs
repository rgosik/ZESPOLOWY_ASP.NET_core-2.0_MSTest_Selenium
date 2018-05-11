using AspCoreApp.Controllers;
using AspCoreApp.Data;
using AspCoreApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using Moq;
using System.Collections.Generic;

namespace UnitTest.Controllers
{
    [TestClass]
    public class KluczControllerMoqTest
    {
        //[TestMethod]
        public async Task KluczIndexMoqTest()
        {
            var key1 = new Klucz(){ Id = "0", };
            var key2 = new Klucz() { Id = "1", };
            var keys = new List<Klucz>();
            keys.Add(key1);
            keys.Add(key2);

            var service = new Mock<IKluczRepository>();
            service.Setup(x => x.GetById("0")).ReturnsAsync(key1);
            service.Setup(x => x.GetById("1")).ReturnsAsync(key2);
            var controller = new KluczController(service.Object);

            var result = await controller.Index();

            var keyModel = ((ViewResult)result).Model as IList<Klucz>;
            //CollectionAssert.AreEqual(keys, keyModel);
            Assert.IsInstanceOfType(keyModel, typeof(IList<Klucz>));
        }

        [TestMethod]
        public async Task KluczDetailMoqTest()
        {
            var key1 = new Klucz() { Id = "0", };
            var service = new Mock<IKluczRepository>();
            service.Setup(x => x.GetById("0")).ReturnsAsync(key1);
            var controller = new KluczController(service.Object);

            var result = await controller.Details(key1.Id);

            var keyModel = ((ViewResult)result).Model as Klucz;
            Assert.AreEqual(key1, keyModel);
        }
        
        [TestMethod]
        public async Task KluczEditMoqTest()
        {
            var key1 = new Klucz() { Id = "0", };
            var service = new Mock<IKluczRepository>();
            service.Setup(x => x.GetById("0")).ReturnsAsync(key1);
            var controller = new KluczController(service.Object);

            var result = await controller.Edit(key1.Id);

            var keyModel = ((ViewResult)result).Model as Klucz;
            Assert.AreEqual(key1, keyModel);
        }
        
        [TestMethod]
        public async Task KluczDeleteMoqTest()
        {
            var key1 = new Klucz() { Id = "0", };
            var service = new Mock<IKluczRepository>();
            service.Setup(x => x.GetById("0")).ReturnsAsync(key1);
            var controller = new KluczController(service.Object);

            var result = await controller.Delete(key1.Id);

            var keyModel = ((ViewResult)result).Model as Klucz;
            Assert.AreEqual(key1, keyModel);

        }
    }
}
