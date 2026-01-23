using System.Linq.Expressions;
using WebAPI.Models;

namespace WebAPI.Repositories.IGenericRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);
        Task<T> GetByIdAsync(int id);
        Task<T> GetByBarcodeAsync(int Barcode);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        void Update(T entity);
        void Remove(T entity);
        Task<int> SaveChangesAsync();
        Task<bool> CheckExistsAsync(Expression<Func<T, bool>>? predicate = null);
        Task<List<Sales>> GetSalesWithDetailsAsync();


    }
}
