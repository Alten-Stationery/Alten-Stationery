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
            using (UnitOfWork u = new UnitOfWork(_context))
            {
                await _context.Set<T>().AddAsync(entity);
                await u.CompleteAsync();
            }
        }

        public async Task DeleteAsync(T entity)
        {
            using (UnitOfWork u = new UnitOfWork(_context))
            {
                _context.Set<T>().Remove(entity);
                await u.CompleteAsync();
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync(int page, int pageSize)
        {
            using (UnitOfWork u = new UnitOfWork(_context))
            {
                if (page <= 1)
                {
                    page = 0;
                }
                int totalNumber = page * pageSize;
                await u.CompleteAsync();
                return await _context.Set<T>().Skip(totalNumber).Take(pageSize).ToListAsync();
            }
        }

        public async Task<T> GetByIdAsync(int id)
        {

            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            T result = await _context.Set<T>().FindAsync(id);
            return result;

        }

        public async Task UpdateAsync(T entity)
        {
            using (UnitOfWork u = new UnitOfWork(_context))
            {
                _context.Set<T>().Update(entity);
                await u.CompleteAsync();
            }
        }
    }
}
