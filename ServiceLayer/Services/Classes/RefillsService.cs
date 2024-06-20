using DBLayer;
using DBLayer.IRepositories;
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
    public class RefillsService : IRefillsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly RefillValidator _validator= new RefillValidator();
        public RefillsService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> CreateAsync(Refill entity)
        {
            try
            {
                var validationResult = await _validator.ValidateAsync(entity);
                if (!validationResult.IsValid)
                {
                    return false;
                }
                await _unitOfWork.Refills.CreateAsync(entity);
                await _unitOfWork.SaveAsync();
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
                var entity = await GetById(id);

                if (entity != null)
                {
                    _unitOfWork.Refills.Delete(entity);
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

        public async Task<IEnumerable<Refill>> GetAllAsync()
        {
            try
            {
                IEnumerable<Refill> refills = await _unitOfWork.Refills.GetAllAsync();
                return refills;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<IEnumerable<Refill>> GetAllAsyncPaginated(int page, int pageSize)
        {
            try
            {
                IEnumerable<Refill> refills = await _unitOfWork.Refills.GetAllAsyncPaginated(page, pageSize);
                return refills;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Refill> GetById(int id)
        {
            try
            {
                Refill refill = await _unitOfWork.Refills.GetByIdAsync(id);
                return refill;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<bool> Update(Refill entity)
        {
            try
            {
                bool check = false;
                var entityToFind = await GetById(entity.RefillId);

                if (entityToFind != null)
                {
                    var validationResult = await _validator.ValidateAsync(entity);
                    if (!validationResult.IsValid)
                    {
                        return check;
                    }
                    _unitOfWork.Refills.Update(entity);
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
