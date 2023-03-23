using Farm.Controllers;
using Farm.Interfaces;
using Farm.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.ControllerTests
{
    public class CattleControllerTests
    {
        private readonly Mock<ICattleRepository> _mockCattleRepository;
        private readonly CattleController _cattleController;

        public CattleControllerTests()
        {
            _mockCattleRepository = new Mock<ICattleRepository>();
            _cattleController = new CattleController(_mockCattleRepository.Object);
        }

        [Fact]
        public void Index_ReturnsAViewResult_WithAListOfCattle()
        {
            // Arrange
            var mockRepository = new Mock<ICattleRepository>();
            mockRepository.Setup(repo => repo.GetAll())
                           .Returns(GetTestCattle());
            var controller = new CattleController(mockRepository.Object);

            // Act
            var result = controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Cattle>>
                (viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }

        private static List<Cattle> GetTestCattle()
        {
            var cattle = new List<Cattle>();
            cattle.Add(new Cattle { Id = 1, Camp = "Rain 1" });
            cattle.Add(new Cattle { Id = 2, Camp = "Rain 2" });
            return cattle;
        }

        [Fact]
        public void Create_ReturnsCreateView()
        {
            // Arrange

            // Act
            var result = _cattleController.Create();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Null(viewResult.ViewName);
        }

        [Fact]
        public void Create_WithValidCattle_ReturnsRedirectToActionResult()
        {
            // Arrange
            var mockRepo = new Mock<ICattleRepository>();
            var controller = new CattleController(mockRepo.Object);
            var cattle = new Cattle { /* fill in properties */ };

            // Act
            var result = controller.Create(cattle) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);
        }
        [Fact]
        public void Delete()
        {
            // Arrange
            var cattleRepositoryMock = new Mock<ICattleRepository>();
            int id = 1;
            var cattle = new Cattle { Id = id };
            cattleRepositoryMock.Setup(repo => repo.GetById(id)).Returns(cattle);
            var controller = new CattleController(cattleRepositoryMock.Object);

            // Act
            var result = controller.Delete(id);

            // Assert
            Assert.IsType<ViewResult>(result);
            var viewResult = result as ViewResult;
            Assert.Equal(viewResult.Model, cattle);
        }




        [Fact]
        public void Delete_InvokesDeleteAndSaveMethodsOnRepository()
        {
            // Arrange
            var mockRepository = new Mock<ICattleRepository>();
            var controller = new CattleController(mockRepository.Object);
            var cattle = new Cattle { Id = 1 };

            // Act
            var result = controller.Delete(cattle) as RedirectToActionResult;

            // Assert
            mockRepository.Verify(r => r.Delete(cattle), Times.Once);
            mockRepository.Verify(r => r.Save(), Times.Once);
            Assert.NotNull(result);
            Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", result.ActionName);
        }
        [Fact]

        public void Details()
        {
            // Arrange
            int id = 1; // Replace with a valid ID for your test case
            var mockRepository = new Mock<ICattleRepository>();
            var expectedCattle = new Cattle { Id = id, /* add other properties as needed */ };
            mockRepository.Setup(repo => repo.GetById(id)).Returns(expectedCattle);
            var controller = new CattleController(mockRepository.Object);

            // Act
            var result = controller.Details(id) as ViewResult;
            var actualCattle = result?.Model as Cattle;

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(actualCattle);
            Assert.Equal(expectedCattle.Id, actualCattle.Id); // Test that the correct rain object is returned
                                                          // Add more assertions as needed to ensure that the view and model are correct

        }

        [Fact]
        public void Edit_ReturnsViewResult_WhenIdIsValid()
        {
            // Arrange
            var mockRepository = new Mock<ICattleRepository>();
            int id = 1;
            var cattle = new Cattle { Id = id, Camp = "Rainy Day" };
            mockRepository.Setup(repo => repo.GetById(id)).Returns(cattle);
            var controller = new CattleController(mockRepository.Object);

            // Act
            var result = controller.Edit(id);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<Cattle>(viewResult.ViewData.Model);
            Assert.Equal(cattle.Id, model.Id);
            Assert.Equal(cattle.Camp, model.Camp);
        }







        [Fact]
        public void Edit_CallsUpdateAndSave_WhenModelStateIsValid()
        {
            // Arrange
            var mockRepository = new Mock<ICattleRepository>();
            var controller = new CattleController(mockRepository.Object);
            var cattle = new Cattle { Id = 1, Camp = "Rainy Day" };

            // Act
            var result = controller.Edit(cattle);

            // Assert
            mockRepository.Verify(repo => repo.Update(cattle), Times.Once);
            mockRepository.Verify(repo => repo.Save(), Times.Once);
            Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public void Details_EditPost_ReturnsRedirectToIndex()
        {
            // Arrange
            var mockRepository = new Mock<ICattleRepository>();
            var controller = new CattleController(mockRepository.Object);

            // Act
            var result = controller.Edit(It.IsAny<Cattle>()) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);
        }

        [Fact]
        public void Details_EditPost_CallsUpdateAndSaveMethods()
        {
            // Arrange
            var mockRepository = new Mock<ICattleRepository>();
            var controller = new CattleController(mockRepository.Object);

            // Act
            var result = controller.Edit(new Cattle());

            // Assert
            mockRepository.Verify(x => x.Update(It.IsAny<Cattle>()), Times.Once);
            mockRepository.Verify(x => x.Save(), Times.Once);
        }
    }
}
