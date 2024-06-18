﻿using DBLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.IServices
{
    public interface IUsersService : IService<User>
    {
        Task<IEnumerable<User>> GetAllAsyncPaginated(int page, int pageSize);
    }
}
