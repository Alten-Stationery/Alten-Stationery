using DBLayer.IRepositories;
using DBLayer.Models;
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
        {  _context = context; }
        public async Task CreateAsync(Refill entity)
        {
            await _context.Refills.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Refill entity)
        {
            _context.Refills.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Refill>> GetAllAsync()
        {
            return await _context.Refills.ToListAsync();
        }

        public async Task<Refill> GetByIdAsync(int id)
        {
            return await _context.Refills.FindAsync(id);
        }

        public async Task UpdateAsync(Refill entity)
        {
            _context.Refills.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
