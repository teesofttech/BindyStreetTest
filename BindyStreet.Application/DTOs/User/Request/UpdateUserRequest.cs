using BindyStreet.Application.DTOs.User.UserRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindyStreet.Application.DTOs.User.Request
{
    public class UpdateUserRequest : CreateUserRequest
    {
        public int Id { get; set; }
    }
}
