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
    public class ItemsRepository : IItemsRepository
    {
        private readonly StationeryContext _context;

        public ItemsRepository(StationeryContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Item entity)
        {
            using (UnitOfWork u = new UnitOfWork(_context))
            {
                await _context.Items.AddAsync(entity);
                await u.CompleteAsync();
            }
        }

        public async Task DeleteAsync(Item entity)
        {
            using (UnitOfWork u = new UnitOfWork(_context))
            {
                _context.Items.Remove(entity);
                await u.CompleteAsync();
            }

        }

        public async Task<IEnumerable<Item>> GetAllAsync(int page, int pageSize)
        {

            using (UnitOfWork u = new UnitOfWork(_context))
            {
                if(page<=1)
                {
                    page = 0;
                }
                int totalNumber = page * pageSize;
                await u.CompleteAsync();
                return await _context.Items.Skip(totalNumber).Take(pageSize).ToListAsync();
            }

        }

        public async Task<Item> GetByIdAsync(int id)
        {
            using (UnitOfWork u = new UnitOfWork(_context))
            {
                await u.CompleteAsync();
                return await _context.Items.FindAsync(id);

            }

        }

        public async Task UpdateAsync(Item entity)
        {

            using (UnitOfWork u = new UnitOfWork(_context))
            {
                _context.Items.Update(entity);
                await u.CompleteAsync();
            }
        }
    }
}
