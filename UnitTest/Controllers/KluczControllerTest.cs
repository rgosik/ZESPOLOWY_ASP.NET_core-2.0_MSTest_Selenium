using AspCoreApp.Controllers;
using AspCoreApp.Data;
using AspCoreApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using UnitTest.Double;

namespace UnitTest.Controllers
{
    [TestClass]
    public class KluczControllerTest
    {
        [TestMethod]
        public async Task KluczIndexTest()
        {
            var kluczRepository = new FakeEntityKluczRepository();
            var kluczController = new KluczController(kluczRepository);

            var result = await kluczController.Index();

            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public async Task KluczDetailTest()
        {
            var kluczRepository = new FakeEntityKluczRepository();
            Klucz key = new Klucz()
            {
                Id = "0",
                Name = "tak",
                Type = 22,
            }; ;
            kluczRepository.Add(key);
            var kluczController = new KluczController(kluczRepository);
            
            var result = await kluczController.Details(key.Id);

            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public async Task KluczCreateTest()
        {
            var kluczRepository = new FakeEntityKluczRepository();
            var kluczController = new KluczController(kluczRepository);

            var result = await kluczController.Create();

            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public async Task KluczEditTest()
        {
            var kluczRepository = new FakeEntityKluczRepository();
            Klucz key = new Klucz()
            {
                Id = "0",
                Name = "tak",
                Type = 22,
            }; ;
            kluczRepository.Add(key);
            var kluczController = new KluczController(kluczRepository);

            var result = await kluczController.Edit(key.Id);

            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public async Task KluczDeleteTest()
        {
            var kluczRepository = new FakeEntityKluczRepository();
            Klucz key = new Klucz()
            {
                Id = "0",
                Name = "tak",
                Type = 22,
            }; ;
            kluczRepository.Add(key);
            var kluczController = new KluczController(kluczRepository);

            var result = await kluczController.Delete(key.Id);

            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
    }
}
