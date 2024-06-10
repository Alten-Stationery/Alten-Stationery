using Azure;
using DBLayer.IRepositories;
using DBLayer.Models;
using DBLayer.UOW;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLayer.Repositories
{
    public class RefillsRepository : IRefillsRepository
    {
        private readonly StationeryContext _context;
        public RefillsRepository(StationeryContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Refill entity)
        {
            using (UnitOfWork u = new UnitOfWork(_context))
            {
                await _context.Refills.AddAsync(entity);
                await u.CompleteAsync();
            }
        }

        public async Task DeleteAsync(Refill entity)
        {
            using (UnitOfWork u = new UnitOfWork(_context))
            {
                _context.Refills.Remove(entity);
                await u.CompleteAsync();
            }

        }

        public async Task<IEnumerable<Refill>> GetAllAsync(int page,int pageSize)
        {

            using (UnitOfWork u = new UnitOfWork(_context))
            {
                if (page <= 1)
                {
                    page = 0;
                }
                int totalNumber = page * pageSize;
                await u.CompleteAsync();
                return await _context.Refills.Skip(totalNumber).Take(pageSize).ToListAsync();
            }

        }

        public async Task<Refill> GetByIdAsync(int id)
        {
            using (UnitOfWork u = new UnitOfWork(_context))
            {
                await u.CompleteAsync();
                return await _context.Refills.FindAsync(id);

            }

        }

        public async Task UpdateAsync(Refill entity)
        {

            using (UnitOfWork u = new UnitOfWork(_context))
            {
                _context.Refills.Update(entity);
                await u.CompleteAsync();
            }
        }
    }
}
