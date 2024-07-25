using DBLayer.IRepositories;
using DBLayer.Models;
using DBLayer.UOW;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DBLayer.Models.Item;

namespace DBLayer.Repositories
{
    public class ItemsRepository : GenericRepository<Item>, IItemsRepository
    {
        private StationeryContext _context;
        public ItemsRepository(StationeryContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Item>> GetAllAsyncByType(ItemType type)
        {
            return await _context.Items.Where(t => t.Type == type).ToListAsync();
        }

        public async Task<IEnumerable<Item>> GetAllAsyncByName(string name, ItemType type)
        {
            return await _context.Items.Where(t => t.Name.Contains(name) && t.Type == type).ToListAsync();
        }
        public async Task<IEnumerable<Item>> GetAllWithFilter(int threshold, string location, ItemType type, int quantity)
        {
            return await _context.Items.Where(t => t.Threshold > threshold && t.Location.Equals(location) &&
                                              t.Type == type && t.Quantity > quantity).ToListAsync();
        }


    }
}
