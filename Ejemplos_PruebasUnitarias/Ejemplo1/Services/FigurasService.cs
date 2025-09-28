using Ejemplo1.DALs;
using Ejemplo1.Models;

namespace Ejemplo1.Services;

public class FigurasService
{
    IFigurasDAL figurasDAL;

    public FigurasService(IFigurasDAL figurasDAL)
    {
        this.figurasDAL = figurasDAL;
    }

    public void Test()
    {
        figurasDAL.Add(new RectanguloModel() { Area = null, Ancho = 1, Largo = 1 });
        figurasDAL.Add(new CirculoModel() { Area = null, Radio = 1 });


        foreach (FiguraModel figura in figurasDAL.GetAll())
        {
            Console.WriteLine(figura);
        }

    }
}
