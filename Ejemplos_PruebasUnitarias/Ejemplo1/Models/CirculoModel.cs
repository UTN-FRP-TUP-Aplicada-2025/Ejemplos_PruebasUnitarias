
namespace Ejemplo1.Models;

public class CirculoModel:FiguraModel
{
    public double? Radio { get; set; }

    public override string ToString()
    {
        return $"Figura:Circulo, Radio:{Radio}";
    }
}
