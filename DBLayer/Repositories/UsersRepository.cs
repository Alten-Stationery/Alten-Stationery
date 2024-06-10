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
    public class UsersRepository : IUsersRepository
    {

        private readonly StationeryContext _context;
        public UsersRepository(StationeryContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(User entity)
        {
            using (UnitOfWork u = new UnitOfWork(_context))
            {
                await _context.Users.AddAsync(entity);
                await u.CompleteAsync();
            }
        }

        public async Task DeleteAsync(User entity)
        {
            using (UnitOfWork u = new UnitOfWork(_context))
            {
                _context.Users.Remove(entity);
                await u.CompleteAsync();
            }

        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {

            using (UnitOfWork u = new UnitOfWork(_context))
            {
                await u.CompleteAsync();
                return await _context.Users.ToListAsync();
            }

        }

        public async Task<User> GetByIdAsync(int id)
        {
            using (UnitOfWork u = new UnitOfWork(_context))
            {
                await u.CompleteAsync();
                return await _context.Users.FindAsync(id);

            }

        }

        public async Task UpdateAsync(User entity)
        {

            using (UnitOfWork u = new UnitOfWork(_context))
            {
                _context.Users.Update(entity);
                await u.CompleteAsync();
            }
        }

    }
}
