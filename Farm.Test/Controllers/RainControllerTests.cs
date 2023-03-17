using Farm.Controllers;
using Farm.Data;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Farm.Test.Controllers
{
    [TestFixture]
    public class RainControllerTests
    {
        private MockRepository mockRepository;

        private Mock<FarmContext> mockFarmContext;

        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockFarmContext = this.mockRepository.Create<FarmContext>();
        }

        private RainController CreateRainController()
        {
            return new RainController(
                this.mockFarmContext.Object);
        }

        [Test]
        public async Task Index_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var rainController = this.CreateRainController();

            // Act
            var result = await rainController.Index();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public async Task ShowSearchForm_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var rainController = this.CreateRainController();

            // Act
            var result = await rainController.ShowSearchForm();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public async Task ShowSearchResults_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var rainController = this.CreateRainController();
            String SearchPhrase = null;

            // Act
            var result = await rainController.ShowSearchResults(
                SearchPhrase);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public async Task Details_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var rainController = this.CreateRainController();
            int? id = null;

            // Act
            var result = await rainController.Details(
                id);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public void Create_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var rainController = this.CreateRainController();

            // Act
            var result = rainController.Create();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public async Task Create_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var rainController = this.CreateRainController();
            RainModel rainModel = null;

            // Act
            var result = await rainController.Create(
                rainModel);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public async Task Edit_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var rainController = this.CreateRainController();
            int? id = null;

            // Act
            var result = await rainController.Edit(
                id);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public async Task Edit_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var rainController = this.CreateRainController();
            int id = 0;
            RainModel rainModel = null;

            // Act
            var result = await rainController.Edit(
                id,
                rainModel);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public async Task Delete_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var rainController = this.CreateRainController();
            int? id = null;

            // Act
            var result = await rainController.Delete(
                id);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public async Task DeleteConfirmed_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var rainController = this.CreateRainController();
            int id = 0;

            // Act
            var result = await rainController.DeleteConfirmed(
                id);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
