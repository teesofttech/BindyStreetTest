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
            var mapped = _mapper.Map<User>(command.UpdateUserRequest);
            var updateQuery = _unitOfWork.UserRepository.Update(mapped);
            var saveUow = _unitOfWork.Save(cancellationToken);
            await Task.WhenAll(updateQuery, saveUow);
            return await Result<int>.SuccessAsync(command.UpdateUserRequest.Id, "User Updated.");
        }

    }

}