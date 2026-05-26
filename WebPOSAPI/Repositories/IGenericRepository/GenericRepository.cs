using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebAPI.Models;

namespace WebAPI.Repositories.IGenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDBContext _context;
        private readonly DbSet<T> _db;
        protected readonly ILogger<GenericRepository<T>> _logger;

        public GenericRepository(AppDBContext context, ILogger<GenericRepository<T>> logger)
        {
            _context = context;
            _db = _context.Set<T>();
            _logger = logger;
        }


        public async Task<T> GetByIdAsync(int id)
        {
            try
            {
                var entity = await _db.FindAsync(id);
                if (entity == null)
                    throw new KeyNotFoundException($"{typeof(T).Name} with id={id} not found");
                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching {Entity} by id {Id}", typeof(T).Name, id);
                throw;
            }
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            try
            {
                if (predicate == null)
                    throw new ArgumentNullException(nameof(predicate));
                return await _db.Where(predicate).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error finding {Entity} with predicate", typeof(T).Name);
                throw;
            }
        }

        public async Task AddAsync(T entity)
        {
            try
            {
                await _db.AddAsync(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding new {Entity}", typeof(T).Name);
                throw;
            }
        }

        public void Update(T entity)
        {
            try
            {
                _db.Update(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating {Entity}", typeof(T).Name);
                throw;
            }
        }

        public void Remove(T entity)
        {
            try
            {
                _db.Remove(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error removing {Entity}", typeof(T).Name);
                throw;
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbEx)
            {
                _logger.LogError(dbEx, "Database update error on SaveChanges for {Entity}", typeof(T).Name);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error on SaveChanges for {Entity}", typeof(T).Name);
                throw;
            }
        }

        public async Task<List<T>> GetAllAsync(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return await query.ToListAsync();
        }
        public async Task<List<Sales>> GetSalesWithDetailsAsync()
        {


            try
            {

                var result = await _context.Sales
                .Include(s => s.SaleItems)
                    .ThenInclude(i => i.Product)
                .Include(s => s.SaleItems)
                    .ThenInclude(i => i.Sizes)
                .ToListAsync();
                return result;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return new List<Sales>();


        }

        public async Task<List<T>> GetAllAsync(params string[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (var include in includeProperties)
            {
                query = query.Include(include);
            }
            return await query.ToListAsync();
        }

        public async Task<bool> CheckExistsAsync(Expression<Func<T, bool>>? predicate = null)
        {
            IQueryable<T> query = _context.Set<T>();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            return await query.AnyAsync();
        }

        public async Task<T> GetByBarcodeAsync(int barcode)
        {
            try
            {
                var entity = await _context.Set<T>()
                    .FirstOrDefaultAsync(e => EF.Property<int>(e, "Barcode") == barcode);

                if (entity == null)
                    throw new KeyNotFoundException($"{typeof(T).Name} with Barcode={barcode} not found");

                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching {Entity} by Barcode {Barcode}", typeof(T).Name, barcode);
                throw;
            }
        }


    }

}


