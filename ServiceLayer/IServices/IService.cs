using DBLayer.Models;
using Microsoft.EntityFrameworkCore;
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
        Task<bool> Delete(int id);
        //Task<bool> DeleteAsync(int id);
        Task<bool> Update(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsyncPaginated(int page, int pageSize);
        Task<T> GetById(int id);
    }
}
