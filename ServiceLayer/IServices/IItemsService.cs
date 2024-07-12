using DBLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DBLayer.Models.Item;

namespace ServiceLayer.IServices
{
    public interface IItemsService:IService<Item>
    {
        Task<IEnumerable<Item>> GetAllAsyncByType(ItemType type);
        Task<IEnumerable<Item>> GetAllAsyncByName(string name);
    }
}
