using BindyStreet.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BindyStreet.Domain.Entities
{
    public class User : BaseEntity
    {
        public int? AddressId { get; set; }
        public int? CompanyId { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }        
        public string Phone { get; set; }
        public string Website { get; set; }
        public Address Address { get; set; }
        public Company Company { get; set; }
    }
}
