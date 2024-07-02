using DBLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DBLayer.Models.Item;

namespace DBLayer.IRepositories
{
    public interface IItemsRepository:IRepository<Item>
    {
        public Task<IEnumerable<Item>> GetAllAsyncByType(ItemType category);
    }
}
