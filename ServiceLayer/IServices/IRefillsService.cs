using DBLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.IServices
{
    public interface IRefillsService:IService<Refill>
    {
        Task<IEnumerable<Refill>> GetAllAsyncPaginated(int page, int pageSize);
    }
}
