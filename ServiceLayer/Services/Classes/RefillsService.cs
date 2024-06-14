using DBLayer.IRepositories;
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
                    await _unitOfWork.Refills.DeleteAsync(entity);
                    check = true;
                }
                return check;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Refill>> GetAllAsync(int page, int pageSize)
        {
            try
            {
                IEnumerable<Refill> refills = await _unitOfWork.Refills.GetAllAsync(page, pageSize);
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

        public async Task<bool> UpdateAsync(Refill entity)
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
                    await _unitOfWork.Refills.UpdateAsync(entity);
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
