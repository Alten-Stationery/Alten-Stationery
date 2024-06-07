using DBLayer.IRepositories;
using DBLayer.Models;
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
            await _context.Alerts.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Alert entity)
        {
            _context.Alerts.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Alert>> GetAllAsync()
        {
            return await _context.Alerts.ToListAsync();
        }

        public async Task<Alert> GetByIdAsync(int id)
        {
            return await _context.Alerts.FindAsync(id);
        }

        public async Task UpdateAsync(Alert entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

    }
}
