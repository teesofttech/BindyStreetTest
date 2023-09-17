using BindyStreet.Application.DTOs.User.UserRequest;
using BindyStreet.Domain.Entities;
using BindyStreet.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindyStreet.Application.Features.UserFeatures.Commands.CreateUser
{
    public record CreateUserCommand : IRequest<Result<int>>
    {
        public CreateUserRequest CreateUserRequest { get; set; }
    }
}
