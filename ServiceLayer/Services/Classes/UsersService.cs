using DBLayer.Models;
using DBLayer.UOW;
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
                    return false;
                }
                await _unitOfWork.Users.CreateAsync(entity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                bool check = false;
                var entity = await _unitOfWork.Users.GetByIdAsync(id);

                if (entity != null)
                {
                    await _unitOfWork.Users.DeleteAsync(entity);
                    check = true;
                }
                return check;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<User>> GetAllAsync(int page)
        {
            try
            {
                int pageSize = 4;
                IEnumerable<User> users = await _unitOfWork.Users.GetAllAsync(page, pageSize);
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
                var entityToFind = await _unitOfWork.Users.GetByIdAsync(entity.UserId);

                if (entityToFind != null)
                {
                    var validationResult = await _validator.ValidateAsync(entity);
                    if (!validationResult.IsValid)
                    {
                        return check;
                    }
                    await _unitOfWork.Users.UpdateAsync(entity);
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
