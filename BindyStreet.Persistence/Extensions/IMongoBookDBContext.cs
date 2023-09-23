using BindyStreet.Domain.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindyStreet.Persistence.Extensions
{
    public interface IMongoBookDBContext
    {
        IMongoCollection<Post> GetCollection<Post>(string name);
    }
}
