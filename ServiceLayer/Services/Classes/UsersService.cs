using DBLayer;
using DBLayer.Models;
using DBLayer.UOW;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.IServices;
using ServiceLayer.Services.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Classes
{
    public class UsersService : IUsersService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserValidator _validator = new UserValidator();
        public UsersService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> CreateAsync(User entity)
        {
            try
            {
                var validationResult = await _validator.ValidateAsync(entity);
                if (!validationResult.IsValid)
                {
                    throw new ArgumentException(validationResult.ToString());
                }
                await _unitOfWork.Users.CreateAsync(entity);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception )
            {
                return false;
            }
        }
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                bool check = false;
                var entity = await GetById(id);

                if (entity != null)
                {
                    await _unitOfWork.Users.DeleteAsync(entity);
                    await _unitOfWork.SaveAsync();
                    check = true;
                }
                return check;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            try
            {
                IEnumerable<User> users = await _unitOfWork.Users.GetAllAsync();
                return users;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<IEnumerable<User>> GetAllAsyncPaginated(int page, int pageSize)
        {
            try
            {
                IEnumerable<User> users = await _unitOfWork.Users.GetAllAsyncPaginated(page, pageSize);
                return users;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<User> GetById(int id)
        {
            try
            {
                User user = await _unitOfWork.Users.GetByIdAsync(id);
                return user;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<bool> UpdateAsync(User entity)
        {
            try
            {
                bool check = false;
                var entityToFind = await GetById(entity.UserId);

                if (entityToFind != null)
                {
                    var validationResult = await _validator.ValidateAsync(entity);
                    if (!validationResult.IsValid)
                    {
                        throw new ArgumentException(validationResult.ToString());
                    }
                    await _unitOfWork.Users.UpdateAsync(entity);
                    await _unitOfWork.SaveAsync();
                    return check = true;
                }
                return check;
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }
}
