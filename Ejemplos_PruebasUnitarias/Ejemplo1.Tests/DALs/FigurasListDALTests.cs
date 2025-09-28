using Xunit;
using Ejemplo1.DALs.List;
using Ejemplo1.Models;

namespace Ejemplo1.Tests.DALs;

public class FigurasListDALTests
{
    private readonly FigurasListDAL _dal;

    public FigurasListDALTests()
    {
        _dal = new FigurasListDAL();
    }

    [Fact]
    public void GetAll_EmptyList_ReturnsEmptyList()
    {
        // Act
        var result = _dal.GetAll();

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void Add_ValidRectangulo_ReturnsAddedFigura()
    {
        // Arrange
        var rectangulo = new RectanguloModel { Area = null, Ancho = 2, Largo = 3 };

        // Act
        var result = _dal.Add(rectangulo);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
        Assert.Equal(2, ((RectanguloModel)result).Ancho);
        Assert.Equal(3, ((RectanguloModel)result).Largo);
    }

    [Fact]
    public void Add_ValidCirculo_ReturnsAddedFigura()
    {
        // Arrange
        var circulo = new CirculoModel { Area = null, Radio = 5 };

        // Act
        var result = _dal.Add(circulo);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
        Assert.Equal(5, ((CirculoModel)result).Radio);
    }

    [Fact]
    public void Add_FiguraWithId_ReturnsNull()
    {
        // Arrange
        var rectangulo = new RectanguloModel { Id = 1, Area = null, Ancho = 2, Largo = 3 };

        // Act
        var result = _dal.Add(rectangulo);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void GetById_ExistingId_ReturnsFigura()
    {
        // Arrange
        var rectangulo = new RectanguloModel { Area = null, Ancho = 2, Largo = 3 };
        _dal.Add(rectangulo);

        // Act
        var result = _dal.GetById(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
        Assert.IsType<RectanguloModel>(result);
    }

    [Fact]
    public void GetById_NonExistingId_ReturnsNull()
    {
        // Act
        var result = _dal.GetById(999);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Save_ExistingRectangulo_UpdatesProperties()
    {
        // Arrange
        var original = new RectanguloModel { Area = null, Ancho = 2, Largo = 3 };
        _dal.Add(original);
        var updated = new RectanguloModel { Id = 1, Area = 10, Ancho = 4, Largo = 5 };

        // Act
        var result = _dal.Save(updated);

        // Assert
        Assert.NotNull(result);
        var rectangulo = Assert.IsType<RectanguloModel>(result);
        Assert.Equal(4, rectangulo.Ancho);
        Assert.Equal(5, rectangulo.Largo);
        Assert.Equal(10, rectangulo.Area);
    }

    [Fact]
    public void Remove_ExistingId_RemovesFigura()
    {
        // Arrange
        var rectangulo = new RectanguloModel { Area = null, Ancho = 2, Largo = 3 };
        _dal.Add(rectangulo);

        // Act
        _dal.Remove(1);
        var result = _dal.GetById(1);

        // Assert
        Assert.Null(result);
    }
}