using DBLayer.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLayer.UOW
{
    public interface IUnitOfWork:IDisposable
    {
        IAlertsRepository Alerts { get; }
        IItemsRepository Items { get; }
        IRefillsRepository Refills { get; }
        IUsersRepository Users { get; }  
        Task<int> CompleteAsync();
        
    }
}
