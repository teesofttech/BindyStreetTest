using AutoMapper;
using BindyStreet.Application.Repositories;
using BindyStreet.Application.Specifications;
using BindyStreet.Shared;
using MediatR;

namespace BindyStreet.Application.Features.UserFeatures.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<Result<GetUserByIdDto>>
    {
        public int Id { get; set; }

        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }

    internal class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, Result<GetUserByIdDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<GetUserByIdDto>> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
        {
            var userSpec = new UsersWithAddressSpecification(query.Id);
            var entity = await _unitOfWork.UserRepository.GetEntityWithSpec(userSpec);
            var user = _mapper.Map<GetUserByIdDto>(entity);

            return await Result<GetUserByIdDto>.SuccessAsync(user);
        }

    }
}
