using BindyStreet.Application.Repositories;
using BindyStreet.Domain.Entities;
using BindyStreet.Persistence.Context;
using BindyStreet.Persistence.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindyStreet.Persistence.Repositories
{
    public class PostRepository : MongoRepository<Post>, IPostRepository
    {
        private readonly IMongoBookDBContext dbContext;
        public PostRepository(IMongoBookDBContext context) : base(context)
        {
            dbContext = context;
        }
    }
}
