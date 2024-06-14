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
    public class ItemsRepository : GenericRepository<Item>, IItemsRepository
    {
        public ItemsRepository(StationeryContext context) : base(context)
        {
        }
    }
}
