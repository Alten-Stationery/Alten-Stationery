using DBLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.IServices
{
    public interface IItemsService:IService<Item>
    {
        Task<IEnumerable<Item>> GetAllAsyncPaginated(int page, int pageSize);
    }
}
