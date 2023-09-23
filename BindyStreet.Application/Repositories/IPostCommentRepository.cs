using BindyStreet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindyStreet.Application.Repositories
{
    public interface IPostCommentRepository : IRepository<Comment>
    {
        Task<List<Comment>> GetPostCommentsById(int id);
    }
}
