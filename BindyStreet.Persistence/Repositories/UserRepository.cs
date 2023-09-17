using BindyStreet.Application.Repositories;
using BindyStreet.Domain.Entities;
using BindyStreet.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace BindyStreet.Persistence.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly BindyStreetContext dbContext;
        public UserRepository(BindyStreetContext _DbContext) : base(_DbContext)
        {
            dbContext = _DbContext;
        }

        //another way to use include, and split query
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

