using Libreria.Models;

namespace Libreria.BusinessLogicLayer.Servicios.Contracts;

public interface ICategoriumService
{
    Task<Categorium> AddCategoría(Categorium categoría);
    Task<Categorium> DeleteCategoría(int id);
    Task<IQueryable<Categorium>> GetAllCategorías();
    Task<Categorium> GetCategoríaById(int id);
    Task<Categorium> UpdateCategoría(Categorium categoría);
    Task<bool> DeleteAllCategorías(List<int> ids);
}
