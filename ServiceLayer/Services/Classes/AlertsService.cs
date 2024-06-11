using DBLayer.IRepositories;
using DBLayer.Models;
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

        private readonly AlertValidator _validator;
        private readonly IAlertsRepository _rep;
        public AlertsService(AlertValidator validator, IAlertsRepository rep)
        {
            _validator = validator;
            _rep = rep;
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
                await _rep.CreateAsync(entity);
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
                var entity = await _rep.GetByIdAsync(id);

                if (entity != null)
                {
                    await _rep.DeleteAsync(entity);
                    check = true;
                }
                return check;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Alert>> GetAllAsync(int page)
        {
            try
            {
                int pageSize = 4;
                IEnumerable<Alert> alerts = await _rep.GetAllAsync(page, pageSize);
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
                Alert alert = await _rep.GetByIdAsync(id);
                return alert;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<bool> UpdateAsync(Alert entity)
        {
            try
            {
                bool check = false;
                var entityToFind = await _rep.GetByIdAsync(entity.AlertId);

                if (entityToFind != null)
                {
                    var validationResult = await _validator.ValidateAsync(entity);
                    if (!validationResult.IsValid)
                    {
                        return check;
                    }
                    await _rep.UpdateAsync(entity);
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
