using BindyStreet.Application.DTOs.User.UserRequest;
using BindyStreet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindyStreet.Application.DTOs.User.Response
{
    public class GetAllUsersDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public AddressDto Address { get; set; }
        public CompanyDto Company { get; set; }
    }
}
