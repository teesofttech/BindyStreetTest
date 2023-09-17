using AutoMapper;
using BindyStreet.Application.Repositories;
using BindyStreet.Domain.Entities;
using BindyStreet.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BindyStreet.Application.Features.UserFeatures.Commands.UpdateUser
{

    internal class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(command.UpdateUserRequest.Id);
            if (user != null)
            {
                var mapped = _mapper.Map<User>(command.UpdateUserRequest);
                await _unitOfWork.UserRepository.Update(user);
                // user.AddDomainEvent(new UserUpdatedEvent(user));

                await _unitOfWork.Save(cancellationToken);

                return await Result<int>.SuccessAsync(user.Id, "User Updated.");
            }
            else
            {
                return await Result<int>.FailureAsync("User Not Found.");
            }
        }
    }

}