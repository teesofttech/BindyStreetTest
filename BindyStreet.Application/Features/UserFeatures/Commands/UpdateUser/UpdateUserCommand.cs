using BindyStreet.Application.DTOs.User.Request;
using BindyStreet.Shared;
using MediatR;

namespace BindyStreet.Application.Features.UserFeatures.Commands.UpdateUser
{
    public record UpdateUserCommand : IRequest<Result<int>>
    {
        public UpdateUserRequest UpdateUserRequest { get; set; }
    }
}
