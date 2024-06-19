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
    public class ItemsService : IItemsService
    {
        private readonly ItemValidator _validator=new ItemValidator();
        private readonly IUnitOfWork _unitOfWork;
        public ItemsService( IUnitOfWork  unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
                await _unitOfWork.Items.CreateAsync(entity);
                await _unitOfWork.SaveAsync();
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
                var entity = await GetById(id);

                if (entity != null)
                {
                    _unitOfWork.Items.Delete(entity);
                    await _unitOfWork.SaveAsync();
                    check = true;
                }          
                return check;
            }catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            try
            {
                IEnumerable<Item> items = await _unitOfWork.Items.GetAllAsync();
                return items;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<IEnumerable<Item>> GetAllAsyncPaginated(int page, int pageSize)
        {
            try
            {
                IEnumerable<Item> items = await _unitOfWork.Items.GetAllAsyncPaginated(page, pageSize);
                return items;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Item> GetById(int id)
        {
            try
            {
               Item item= await _unitOfWork.Items.GetByIdAsync(id);
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
                var entityToFind = await GetById(entity.ItemId);

                if (entityToFind != null)
                {
                    var validationResult = await _validator.ValidateAsync(entity);
                    if (!validationResult.IsValid)
                    {
                        return check;
                    }                   
                    _unitOfWork.Items.Delete(entity);
                    await _unitOfWork.SaveAsync();
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
