using BindyStreet.Application.DTOs.User.Response;
using BindyStreet.Application.Repositories;
using BindyStreet.Domain.Entities;
using BindyStreet.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindyStreet.Persistence.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly BindyStreetContext dbContext;
        public UserRepository(BindyStreetContext _DbContext) : base(_DbContext)
        {
            dbContext = _DbContext;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await dbContext.Users
                        .AsSplitQuery()
                        .Include(x => x.Address.Geo)
                        .Include(x => x.Company)
                        .ToListAsync();
        }
    }

}

