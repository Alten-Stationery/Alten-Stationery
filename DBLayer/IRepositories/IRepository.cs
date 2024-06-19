using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLayer.IRepositories
{
    public interface IRepository<T>
    {
        public Task CreateAsync(T entity);
        public void Update(T entity);
        public void Delete(T entity);
        public Task<T> GetByIdAsync(int id);
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<IEnumerable<T>> GetAllAsyncPaginated(int page, int pageSize);
    }
}
