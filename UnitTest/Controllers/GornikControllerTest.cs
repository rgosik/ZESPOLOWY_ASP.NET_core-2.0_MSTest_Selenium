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
    public class GornikControllerTest
    {
        [TestMethod]
        public async Task GornikIndexTest()
        {
            var kluczRepository = new FakeEntityKluczRepository();
            var gornikRepository = new FakeEntityGornikRepository();
            var gornikController = new GornikController(gornikRepository, kluczRepository);

            var result = await gornikController.Index();

            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public async Task GornikDetailFailTest()
        {
            var kluczRepository = new FakeEntityKluczRepository();
            var gornikRepository = new FakeEntityGornikRepository();
            var gornikController = new GornikController(gornikRepository, kluczRepository);

            var result = await gornikController.Details("0");

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task GornikCreateTest()
        {
            var kluczRepository = new FakeEntityKluczRepository();
            var gornikRepository = new FakeEntityGornikRepository();
            var gornikController = new GornikController(gornikRepository, kluczRepository);

            var result = await gornikController.Create();

            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public async Task GornikEditFailTest()
        {
            var kluczRepository = new FakeEntityKluczRepository();
            var gornikRepository = new FakeEntityGornikRepository();
            var gornikController = new GornikController(gornikRepository, kluczRepository);

            var result = await gornikController.Edit("lel");

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task GornikEditDeleteTest()
        {
            var kluczRepository = new FakeEntityKluczRepository();
            var gornikRepository = new FakeEntityGornikRepository();
            var gornikController = new GornikController(gornikRepository, kluczRepository);

            var result = await gornikController.Delete("lel");

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    }
}
