using DBLayer.IRepositories;
using DBLayer.UOW;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLayer.Repositories
{
    public abstract class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly StationeryContext _context;
        public GenericRepository(StationeryContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }
        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
        public async Task<IEnumerable<T>> GetAllAsyncPaginated(int page, int pageSize)
        {
            if (page <= 1)
            {
                page = 0;
            }
            int totalNumber = page * pageSize;
            return await _context.Set<T>().Skip(totalNumber).Take(pageSize).ToListAsync();
        }
        public async Task<T> GetByIdAsync(int id)
        {
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            T result = await _context.Set<T>().FindAsync(id);
            return result;
        }
        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
