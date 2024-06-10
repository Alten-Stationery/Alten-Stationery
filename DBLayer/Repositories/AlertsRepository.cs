using DBLayer.IRepositories;
using DBLayer.Models;
using DBLayer.UOW;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLayer.Repositories
{
    public class AlertsRepository : IAlertsRepository
    {
        private readonly StationeryContext _context;

        public AlertsRepository(StationeryContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Alert entity)
        {
            using (UnitOfWork u =new UnitOfWork(_context))
            {
                await _context.Alerts.AddAsync(entity);
                await u.CompleteAsync();
            }        
        }

        public async Task DeleteAsync(Alert entity)
        {
            using (UnitOfWork u = new UnitOfWork(_context))
            {
                _context.Alerts.Remove(entity);
                await u.CompleteAsync();
            }
            
        }

        public async Task<IEnumerable<Alert>> GetAllAsync(int page, int pageSize)
        {

            using (UnitOfWork u = new UnitOfWork(_context))
            {
                if (page <= 1)
                {
                    page = 0;
                }
                int totalNumber = page * pageSize;
                await u.CompleteAsync();
                return await _context.Alerts.Skip(totalNumber).Take(pageSize).ToListAsync();
            }
            
        }

        public async Task<Alert> GetByIdAsync(int id)
        {
            using (UnitOfWork u = new UnitOfWork(_context))
            {
                await u.CompleteAsync();
                return await _context.Alerts.FindAsync(id);
                
            }
            
        }

        public async Task UpdateAsync(Alert entity)
        {

            using (UnitOfWork u = new UnitOfWork(_context))
            {
                _context.Alerts.Update(entity);
                await u.CompleteAsync();
            }
        }

    }
}
