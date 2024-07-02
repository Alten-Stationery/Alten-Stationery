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

        public async Task<IEnumerable<Item>> GetAllAsyncByType(ItemType category)
        {
            
            return await _context.Items.Where(t=>t.Type==category).ToListAsync();

        }
    }
}
