using AutoMapper;
using BindyStreet.Application.DTOs.User.Response;
using BindyStreet.Application.Repositories;
using BindyStreet.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BindyStreet.Application.Features.UserFeatures.Queries.GetAllUsers
{
    public record GetAllUsersQuery : IRequest<Result<List<GetAllUsersDto>>>;

    internal class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, Result<List<GetAllUsersDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllUsersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<List<GetAllUsersDto>>> Handle(GetAllUsersQuery query, CancellationToken cancellationToken)
        {
            var users = await _unitOfWork.UserRepository.GetAllUsers();
            var mapped = _mapper.Map<List<GetAllUsersDto>>(users);
            return await Result<List<GetAllUsersDto>>.SuccessAsync(mapped);
        }
    }
}

