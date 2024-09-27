using Libreria.Models;

namespace Libreria.BusinessLogicLayer.Servicios.Contracts;

public interface ICategoríaService
{
    Task<Categoría> AddCategoría(Categoría categoría);
    Task<Categoría> DeleteCategoría(int id);
    Task<IQueryable<Categoría>> GetAllCategorías();
    Task<Categoría> GetCategoríaById(int id);
    Task<Categoría> UpdateCategoría(Categoría categoría);
}
