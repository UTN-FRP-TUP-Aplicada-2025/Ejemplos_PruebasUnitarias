using Ejemplo1.Models;
using System.Data;

namespace Ejemplo1.DALs.List;

public class FigurasListDAL: IFigurasDAL
{
    private List<FiguraModel> figuras;

    public FigurasListDAL()
    {
        figuras = new List<FiguraModel>();
    }

    public List<FiguraModel> GetAll()
    {
        return (
               from figura in figuras
               select figura
                ).ToList();
    }

    public FiguraModel? GetById(int id)
    {
        return (
               from figura in figuras
               where figura.Id==id
               select figura
                ).FirstOrDefault();
    }

    public FiguraModel? Add(FiguraModel figura)
    {
        if (figura.Id != null) return null;

        int maxId = 0;
        if (figuras.Count > 0)
        {
            maxId = (
                from f in figuras
                select f.Id ?? 0
                ).Max();
        }
        figura.Id = maxId + 1;
        figuras.Add(figura);
        return figura;
    }

    public FiguraModel? Save(FiguraModel nuevo)
    {
        FiguraModel? original = GetById(nuevo.Id??0);
        if (original == null ) return null;

        if (nuevo is RectanguloModel r && original is RectanguloModel ro)
        { 
            ro.Ancho = r.Ancho;
            ro.Largo = r.Largo;
            ro.Area = r.Area;
            return ro;
        }
        else if (nuevo is CirculoModel c && original is CirculoModel co)
        {
            co.Area = c.Area;
            co.Radio = c.Radio;
            return co;
        }

        return null;
    }

    public void Remove(int id)
    {
        FiguraModel? original = GetById(id);
        if (original != null)
        {
            figuras.Remove(original);
        }
    }
}
