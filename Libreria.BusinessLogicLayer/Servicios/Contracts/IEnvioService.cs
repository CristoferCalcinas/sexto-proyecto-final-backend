using Libreria.Models;

namespace Libreria.BusinessLogicLayer.Servicios.Contracts;

public interface IEnvioService
{
    Task<Envio> AddEnvio(Envio envio);
    Task<Envio> DeleteEnvio(int id);
    Task<IQueryable<Envio>> GetAllEnvios();
    Task<Envio> GetEnvioById(int id);
    Task<Envio> UpdateEnvio(Envio envio);
}
