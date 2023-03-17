using Farm.Controllers;
using Farm.Data;
using Farm.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;

namespace TestProject4.Controllers
{
    [TestClass]
    public class CattleControllerTests
    {
        private MockRepository mockRepository;

        private Mock<FarmContext> mockFarmContext;


        

        

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Default);

            this.mockFarmContext = this.mockRepository.Create<FarmContext>();
        }

        private CattleController CreateCattleController()
        {
            return new CattleController(
                this.mockFarmContext.Object);
        }

        [TestMethod]
        public void Index()
        {
            //Arrange

            HomeController controller = new HomeController();

            //Act

            ViewResult result = controller.Index() as ViewResult;

            //Assert

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task ShowSearchForm_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var cattleController = this.CreateCattleController();

            // Act
            var result = await cattleController.ShowSearchForm();

            // Assert
            Assert.IsNotNull(result);
            this.mockRepository.VerifyAll();
        }

        //[TestMethod]
        //public async Task ShowSearchResultsCamp_StateUnderTest_ExpectedBehavior()
        //{
        //    // Arrange
        //    var cattleController = this.CreateCattleController();
        //    String SearchPhrase = null;

        //    // Act
        //    var result = await cattleController.ShowSearchResultsCamp(
        //        SearchPhrase);

        //    // Assert
        //    Assert.IsNotNull(result);
        //    this.mockRepository.VerifyAll();
        //}

        [TestMethod]
        public async Task ShowSearchFormBreed_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var cattleController = this.CreateCattleController();

            // Act
            var result = await cattleController.ShowSearchFormBreed();

            // Assert
            Assert.IsNotNull(result);
            this.mockRepository.VerifyAll();
        }

        //[TestMethod]
        //public async Task ShowSearchResultsBreed_StateUnderTest_ExpectedBehavior()
        //{
        //    // Arrange
        //    var cattleController = this.CreateCattleController();
        //    String SearchPhrase = "bonsmara";

        //    // Act
        //    var result = await cattleController.ShowSearchResultsBreed(
        //        SearchPhrase);

        //    // Assert
        //    Assert.IsNotNull(result);
        //    this.mockRepository.VerifyAll();
        //}

        [TestMethod]
        public async Task Details_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var cattleController = this.CreateCattleController();
            int? id = null;

            // Act
            var result = await cattleController.Details(
                id);

            // Assert
            Assert.IsNotNull(result);
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void Create_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var cattleController = this.CreateCattleController();

            // Act
            var result = cattleController.Create();

            // Assert
            Assert.IsNotNull(result);
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task Create_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var cattleController = this.CreateCattleController();
            Cattle cattle = null;

            // Act
            var result = await cattleController.Create(
                cattle);

            // Assert
            Assert.IsNotNull(result);
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task Edit_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var cattleController = this.CreateCattleController();
            int? id = null;

            // Act
            var result = await cattleController.Edit(
                id);

            // Assert
            Assert.IsNotNull(result);
            this.mockRepository.VerifyAll();
        }

        //[TestMethod]
        //public async Task Edit_StateUnderTest_ExpectedBehavior1()
        //{
        //    // Arrange
        //    var cattleController = this.CreateCattleController();
        //    int id = 0;
        //    Cattle cattle = null;

        //    // Act
        //    var result = await cattleController.Edit(
        //        id,
        //        cattle);

        //    // Assert
        //    Assert.IsNotNull(result);
        //    this.mockRepository.VerifyAll();
        //}

        [TestMethod]
        public async Task Delete_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var cattleController = this.CreateCattleController();
            int? id = null;
            

            // Act
            var result = await cattleController.Delete(
                id);

            // Assert
            Assert.IsNotNull(result);
            this.mockRepository.VerifyAll();
        }

        [TestClass]
        public class DeleteConfirmedTests
        {
            private DbContextOptions<FarmContext> _options;

            [TestInitialize]
            public void TestInitialize()
            {
                _options = new DbContextOptionsBuilder<FarmContext>()
                    .UseInMemoryDatabase(databaseName: "Farm")
                    .Options;
            }

            //[TestMethod]
            //public async Task DeleteConfirmed_WithValidId_ShouldRemoveCattleFromDatabase()
            //{
            //    // Arrange
            //    using (var context = new FarmContext(_options))
            //    {
            //        var cattle = new Cattle { Id = 1, Breed = "Brahman" };
            //        await context.Cattle.AddAsync(cattle);
            //        await context.SaveChangesAsync();
            //    }
            //    using (var context = new FarmContext(_options))
            //    {
            //        var controller = new CattleController(context);

            //        // Act
            //        var result = await controller.DeleteConfirmed(1);

            //        // Assert
            //        Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            //        Assert.AreEqual("Index", ((RedirectToActionResult)result).ActionName);
            //        Assert.IsNull(await context.Cattle.FindAsync(1));
            //    }
            //}

            //[TestMethod]
            //public async Task DeleteConfirmed_WithInvalidId_ShouldNotRemoveCattleFromDatabase()
            //{
            //    // Arrange
            //    using (var context = new FarmContext(_options))
            //    {
            //        var cattle = new Cattle { Id = 1, Breed = "Bonsmara" };
            //        await context.Cattle.AddAsync(cattle);
            //        await context.SaveChangesAsync();
            //    }
            //    using (var context = new FarmContext(_options))
            //    {
            //        var controller = new CattleController(context);

            //        // Act
            //        var result = await controller.DeleteConfirmed(2);

            //        // Assert
            //        Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            //        Assert.AreEqual("Index", ((RedirectToActionResult)result).ActionName);
            //        Assert.IsNotNull(await context.Cattle.FindAsync(1));
            //    }
            //}

            //[TestMethod]
            //public async Task DeleteConfirmed_WithNullCattleSet_ShouldReturnProblem()
            //{
            //    // Arrange
            //    using (var context = new FarmContext(_options))
            //    {
            //        context.Cattle = null;
            //    }
            //    using (var context = new FarmContext(_options))
            //    {
            //        var controller = new CattleController(context);

            //        // Act
            //        var result = await controller.DeleteConfirmed(1);

            //        // Assert
            //        Assert.IsInstanceOfType(result, typeof(ObjectResult));
            //        Assert.AreEqual("Entity set 'FarmContext.Cattle' is null.", ((ObjectResult)result).Value);
            //    }
            //}
        }



    }
}
