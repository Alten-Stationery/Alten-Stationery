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
    public class AlertsService : IAlertsService
    {
        private readonly AlertValidator _validator = new AlertValidator();
        private readonly IUnitOfWork _unitOfWork;
        public AlertsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateAsync(Alert entity)
        {
            try
            {
                var validationResult = await _validator.ValidateAsync(entity);
                if (!validationResult.IsValid)
                {
                    return false;
                }
                await _unitOfWork.Alerts.CreateAsync(entity);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                bool check = false;
                var entity = await GetById(id);

                if (entity != null)
                {
                     _unitOfWork.Alerts.Delete(entity);
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

        public async Task<IEnumerable<Alert>> GetAllAsync()
        {
            try
            {
                IEnumerable<Alert> alerts = await _unitOfWork.Alerts.GetAllAsync();
                return alerts;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<IEnumerable<Alert>> GetAllAsyncPaginated(int page, int pageSize)
        {
            try
            {
                IEnumerable<Alert> alerts = await _unitOfWork.Alerts.GetAllAsyncPaginated(page, pageSize);
                return alerts;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Alert> GetById(int id)
        {
            try
            {
                Alert alert = await _unitOfWork.Alerts.GetByIdAsync(id);
                return alert;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Task<bool> Update(Alert entity)
        {
            try
            {
                bool check = false;
                var entityToFind = GetById(entity.AlertId);

                if (entityToFind != null)
                {
                    var validationResult = _validator.ValidateAsync(entity);
                    if (!validationResult.IsValid)
                    {
                        return check;
                    }
                    _unitOfWork.Alerts.Update(entity);
                    _unitOfWork.SaveAsync();
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
