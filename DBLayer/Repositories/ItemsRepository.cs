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
    public class ItemsRepository : IItemsRepository
    {
        private readonly StationeryContext _context;

        public ItemsRepository(StationeryContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Item entity)
        {
            await _context.Items.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Item entity)
        {
            _context.Items.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            return await _context.Items.ToListAsync();
        }

        public async Task<Item> GetByIdAsync(int id)
        {
            return await _context.Items.FindAsync(id);
        }

        public async Task UpdateAsync(Item entity)
        {
             _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
