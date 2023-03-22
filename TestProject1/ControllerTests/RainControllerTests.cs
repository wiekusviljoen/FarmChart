using System.Collections.Generic;
using Farm.Controllers;
using Farm.Interfaces;
using Farm.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

public class RainControllerTests

    
{
    private readonly Mock<IRainRepository> _mockRainRepository;
    private readonly RainController _rainController;

    public RainControllerTests()
    {
        _mockRainRepository = new Mock<IRainRepository>();
        _rainController = new RainController(_mockRainRepository.Object);
    }

    [Fact]
    public void Index_ReturnsAViewResult_WithAListOfRainModels()
    {
        // Arrange
        var mockRepository = new Mock<IRainRepository>();
        mockRepository.Setup(repo => repo.GetAll())
                       .Returns(GetTestRainModels());
        var controller = new RainController(mockRepository.Object);

        // Act
        var result = controller.Index();

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsAssignableFrom<IEnumerable<RainModel>>
            (viewResult.ViewData.Model);
        Assert.Equal(2, model.Count());
    }

    private static List<RainModel> GetTestRainModels()
    {
        var rains = new List<RainModel>();
        rains.Add(new RainModel { Id = 1, Camp = "Rain 1" });
        rains.Add(new RainModel { Id = 2, Camp = "Rain 2" });
        return rains;
    }

    [Fact]
    public void Create_ReturnsCreateView()
    {
        // Arrange

        // Act
        var result = _rainController.Create();

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        Assert.Null(viewResult.ViewName);
    }

    [Fact]
    public void Create_WithValidRainModel_ReturnsRedirectToActionResult()
    {
        // Arrange
        var mockRepo = new Mock<IRainRepository>();
        var controller = new RainController(mockRepo.Object);
        var rainModel = new RainModel { /* fill in properties */ };

        // Act
        var result = controller.Create(rainModel) as RedirectToActionResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Index", result.ActionName);
    }
    [Fact]
    public void Delete()
    {
        // Arrange
        var rainRepositoryMock = new Mock<IRainRepository>();
        int id = 1;
        var rainModel = new RainModel { Id = id };
        rainRepositoryMock.Setup(repo => repo.GetById(id)).Returns(rainModel);
        var controller = new RainController(rainRepositoryMock.Object);

        // Act
        var result = controller.Delete(id);

        // Assert
        Assert.IsType<ViewResult>(result);
        var viewResult = result as ViewResult;
        Assert.Equal(viewResult.Model, rainModel);
    }

    
    

    [Fact]
    public void Delete_InvokesDeleteAndSaveMethodsOnRepository()
    {
        // Arrange
        var mockRepository = new Mock<IRainRepository>();
        var controller = new RainController(mockRepository.Object);
        var rainModel = new RainModel { Id = 1 };

        // Act
        var result = controller.Delete(rainModel) as RedirectToActionResult;

        // Assert
        mockRepository.Verify(r => r.Delete(rainModel), Times.Once);
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
        var mockRepository = new Mock<IRainRepository>();
        var expectedRain = new RainModel { Id = id, /* add other properties as needed */ };
        mockRepository.Setup(repo => repo.GetById(id)).Returns(expectedRain);
        var controller = new RainController(mockRepository.Object);

        // Act
        var result = controller.Details(id) as ViewResult;
        var actualRain = result?.Model as RainModel;

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(actualRain);
        Assert.Equal(expectedRain.Id, actualRain.Id); // Test that the correct rain object is returned
                                                      // Add more assertions as needed to ensure that the view and model are correct

    }

    [Fact]
    public void Edit_ReturnsViewResult_WhenIdIsValid()
    {
        // Arrange
        var mockRepository = new Mock<IRainRepository>();
        int id = 1;
        var rainModel = new RainModel { Id = id, Camp = "Rainy Day" };
        mockRepository.Setup(repo => repo.GetById(id)).Returns(rainModel);
        var controller = new RainController(mockRepository.Object);

        // Act
        var result = controller.Edit(id);

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsAssignableFrom<RainModel>(viewResult.ViewData.Model);
        Assert.Equal(rainModel.Id, model.Id);
        Assert.Equal(rainModel.Camp, model.Camp);
    }

    
    

    
    

    [Fact]
    public void Edit_CallsUpdateAndSave_WhenModelStateIsValid()
    {
        // Arrange
        var mockRepository = new Mock<IRainRepository>();
        var controller = new RainController(mockRepository.Object);
        var rainModel = new RainModel { Id = 1, Camp = "Rainy Day" };

        // Act
        var result = controller.Edit(rainModel);

        // Assert
        mockRepository.Verify(repo => repo.Update(rainModel), Times.Once);
        mockRepository.Verify(repo => repo.Save(), Times.Once);
        Assert.IsType<RedirectToActionResult>(result);
    }

    [Fact]
    public void Details_EditPost_ReturnsRedirectToIndex()
    {
        // Arrange
        var mockRepository = new Mock<IRainRepository>();
        var controller = new RainController(mockRepository.Object);

        // Act
        var result = controller.Edit(It.IsAny<RainModel>()) as RedirectToActionResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Index", result.ActionName);
    }

    [Fact]
    public void Details_EditPost_CallsUpdateAndSaveMethods()
    {
        // Arrange
        var mockRepository = new Mock<IRainRepository>();
        var controller = new RainController(mockRepository.Object);

        // Act
        var result = controller.Edit(new RainModel());

        // Assert
        mockRepository.Verify(x => x.Update(It.IsAny<RainModel>()), Times.Once);
        mockRepository.Verify(x => x.Save(), Times.Once);
    }
}
