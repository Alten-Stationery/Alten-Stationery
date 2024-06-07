using DBLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLayer.IRepositories
{
    public interface IUsersRepository : IRepository<User>
    {

        Task CreateAsync(User entity);

        Task DeleteAsync(User entity);

        Task<IEnumerable<User>> GetAllAsync();

        Task<User> GetByIdAsync(int id);

        Task UpdateAsync(User entity);

    }
}
