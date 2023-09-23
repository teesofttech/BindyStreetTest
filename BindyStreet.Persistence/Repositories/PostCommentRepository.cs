using BindyStreet.Application.Repositories;
using BindyStreet.Domain.Entities;
using BindyStreet.Persistence.Extensions;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindyStreet.Persistence.Repositories
{
    public class PostCommentRepository : MongoRepository<Comment>, IPostCommentRepository
    {
        private readonly IMongoBookDBContext dbContext;
        public PostCommentRepository(IMongoBookDBContext context) : base(context)
        {
            dbContext = context;
        }

        public async Task<List<Comment>> GetPostCommentsById(int id)
        {
            var objectId = new BsonInt32(id);
            FilterDefinition<Comment> filter = Builders<Comment>.Filter.Eq("PostId", objectId);
            var comments = await dbContext.GetCollection<Comment>("Comment").Find(filter).ToListAsync();
            return comments;
        }
    }
}
