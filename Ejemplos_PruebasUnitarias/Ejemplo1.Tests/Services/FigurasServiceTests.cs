using Xunit;
using Moq;
using Ejemplo1.Services;
using Ejemplo1.DALs;
using Ejemplo1.Models;

namespace Ejemplo1.Tests.Services;

public class FigurasServiceTests
{
    private readonly Mock<IFigurasDAL> _mockFigurasDAL;
    private readonly FigurasService _service;

    public FigurasServiceTests()
    {
        _mockFigurasDAL = new Mock<IFigurasDAL>();
        _service = new FigurasService(_mockFigurasDAL.Object);
    }

    [Fact]
    public void Test_AddsRectanguloAndCirculo_AndGetsAll()
    {
        // Arrange
        var figuras = new List<FiguraModel>();
        _mockFigurasDAL.Setup(dal => dal.Add(It.IsAny<FiguraModel>()))
            .Returns<FiguraModel>(f => 
            {
                f.Id = figuras.Count + 1;
                figuras.Add(f);
                return f;
            });

        _mockFigurasDAL.Setup(dal => dal.GetAll())
            .Returns(figuras);

        // Act
        _service.Test();

        // Assert
        _mockFigurasDAL.Verify(dal => dal.Add(It.IsAny<RectanguloModel>()), Times.Once);
        _mockFigurasDAL.Verify(dal => dal.Add(It.IsAny<CirculoModel>()), Times.Once);
        _mockFigurasDAL.Verify(dal => dal.GetAll(), Times.Once);
        Assert.Equal(2, figuras.Count);
        Assert.IsType<RectanguloModel>(figuras[0]);
        Assert.IsType<CirculoModel>(figuras[1]);
    }
}