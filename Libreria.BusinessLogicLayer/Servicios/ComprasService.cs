using Libreria.BusinessLogicLayer.Servicios.Contracts;
using Libreria.DataAccessLayer.Repositories.Contract;
using Libreria.Models;

namespace Libreria.BusinessLogicLayer.Servicios;

public class ComprasService : IComprasService
{
    private readonly IGenericRepository<Compra> _genericRepository;
    public ComprasService(IGenericRepository<Compra> genericRepository)
    {
        _genericRepository = genericRepository;
    }

    public async Task<Compra> AddCompra(Compra compra)
    {
        return await _genericRepository.AddAsync(compra);
    }

    public async Task<Compra> DeleteCompra(int id)
    {
        return await _genericRepository.DeleteAsync(id);
    }

    public async Task<IQueryable<Compra>> GetAllCompras()
    {
        return await _genericRepository.GetAllAsync();
    }

    public async Task<Compra> GetCompraById(int id)
    {
        return await _genericRepository.GetByIdAsync(id);
    }

    public async Task<Compra> UpdateCompra(Compra compra)
    {
        return await _genericRepository.UpdateAsync(compra);
    }
}
