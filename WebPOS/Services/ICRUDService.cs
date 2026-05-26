namespace WebPOS.Services
{
    public interface ICRUDService<T> where T : class
    {
        Task<List<T>> GetAllAsync();

        Task<T?> GetByIdAsync(int id);

        Task<bool> AddAsync(T entity);

        Task<bool> UpdateAsync(int id, T entity);

        Task<bool> DeleteAsync(int id);

    }
}
