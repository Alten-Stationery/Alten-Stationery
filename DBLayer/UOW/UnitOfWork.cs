using DBLayer.IRepositories;
using DBLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLayer.UOW
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly StationeryContext _context;
        public IAlertsRepository Alerts {  get; set; }
        public IUsersRepository Users { get; set; }
        public IRefillsRepository Refills { get; set; }
        public IItemsRepository Items { get; set; }
        public UnitOfWork(StationeryContext context) 
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            Alerts= new AlertsRepository(context);
            Users= new UsersRepository(context);
            Refills= new RefillsRepository(context);
            Items= new ItemsRepository(context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
