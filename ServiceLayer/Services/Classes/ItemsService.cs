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
    public class ItemsService : IItemsService
    {
        private readonly ItemValidator _validator;
        private readonly IItemsRepository _rep;
        public ItemsService(ItemValidator validator, IItemsRepository rep)
        {
            _validator = validator;
            _rep = rep;
        }

        public async Task<bool> CreateAsync(Item entity)
        {
            try
            {
                var validationResult= await _validator.ValidateAsync(entity);
                if(!validationResult.IsValid)
                {
                    return false;
                }
                await _rep.CreateAsync(entity);
                return true;
            }catch (Exception ex)
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
                    check= true;
                }          
                return check;
            }catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Item>> GetAllAsync(int page)
        {
            try
            {
                int pageSize = 4;
                IEnumerable<Item> items= await _rep.GetAllAsync(page,pageSize);
                return items;
            }
            catch(Exception ex)
            {
                return null;
            }
           
            
        }

        public async Task<Item> GetById(int id)
        {
            try
            {
               Item item= await _rep.GetByIdAsync(id);
                return item;
            }catch(Exception e)
            {
                return null;
            }
        }

        public async Task<bool> UpdateAsync(Item entity)
        {
            try
            {
                bool check = false;
                var entityToFind = await _rep.GetByIdAsync(entity.ItemId);

                if (entityToFind != null)
                {
                    var validationResult = await _validator.ValidateAsync(entity);
                    if (!validationResult.IsValid)
                    {
                        return check;
                    }                   
                    await _rep.UpdateAsync(entity);
                    return check= true;
                }
                return check;
            }
            catch(Exception e)
            {
                return false;
            }
        }
    }
}
