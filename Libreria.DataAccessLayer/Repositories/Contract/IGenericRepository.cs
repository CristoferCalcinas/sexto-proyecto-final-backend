namespace Libreria.DataAccessLayer.Repositories.Contract;

public interface IGenericRepository<T> where T : class
{
    // Operaciones básicas de consulta
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);

    // Operaciones de creación, actualización y eliminación
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);

    // Operaciones de consulta personalizadas
    Task<List<TResult>> ExecuteQueryAsync<TResult>(string query) where TResult : class;
}
