using Ejemplo1.Models;

namespace Ejemplo1.DALs;

public interface IFigurasDAL
{
    List<FiguraModel> GetAll();
    FiguraModel? GetById(int id);
    FiguraModel? Add(FiguraModel figura);
    FiguraModel? Save(FiguraModel nuevo);
    void Remove(int id);
}
