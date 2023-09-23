using BindyStreet.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindyStreet.Domain.Entities
{
    public class Comment : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Body { get; set; }
        public int PostId { get; set; }
    }
}
