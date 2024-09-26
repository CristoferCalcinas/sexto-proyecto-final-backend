namespace Libreria.DataAccessLayer.Repositories.Contract;

public interface IGenericRepository<T> where T : class
{
    // Operaciones básicas de consulta
    Task<IQueryable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);

    // Operaciones de creación, actualización y eliminación
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(int id);

    // Operaciones de consulta personalizadas
    Task<List<TResult>> ExecuteQueryAsync<TResult>(string query) where TResult : class;
}
