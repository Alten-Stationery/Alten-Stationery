using DBLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLayer.IRepositories
{
    public interface IAlertsRepository : IRepository<Alert>
    {

        Task CreateAsync(Alert entity);

        Task DeleteAsync(Alert entity);

        Task<IEnumerable<Alert>> GetAllAsync();

        Task<Alert> GetByIdAsync(int id);

        Task UpdateAsync(Alert entity);

    }
}
