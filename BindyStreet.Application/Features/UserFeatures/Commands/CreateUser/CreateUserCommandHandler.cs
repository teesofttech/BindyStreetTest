using AutoMapper;
using BindyStreet.Application.DTOs.User.UserRequest;
using BindyStreet.Application.Repositories;
using BindyStreet.Domain.Entities;
using BindyStreet.Shared;
using MediatR;

namespace BindyStreet.Application.Features.UserFeatures.Commands.CreateUser
{
    internal class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<CreateUserRequest, User>(command.CreateUserRequest);
            await _unitOfWork.UserRepository.AddAsync(user);
            //user.AddDomainEvent(new PlayerCreatedEvent(player));
            await _unitOfWork.Save(cancellationToken);
            return await Result<int>.SuccessAsync(user.Id, "User Created.");
        }
    }

}
