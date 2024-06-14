using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.IServices
{
    public interface IService<T>
    {
        Task<bool> CreateAsync(T entity);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync(int page, int pageSize);
        Task<T> GetById(int id);

    }
}
