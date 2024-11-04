using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Ecommerce.EntityFrameworkCore.Repositories
{
    public class EfCoreRepository<T, TContext> : IRepository<T> where T : class where TContext : DbContext
    {
        #region Fields

        protected readonly TContext _context;
        protected readonly DbSet<T> _dbSet;

        #endregion

        #region Ctor

        public EfCoreRepository(TContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        #endregion

        #region Methods

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T?>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        #endregion
    }
}