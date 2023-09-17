using BindyStreet.Application.DTOs.User.Response;
using BindyStreet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindyStreet.Application.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<List<User>> GetAllUsers();
    }
}
