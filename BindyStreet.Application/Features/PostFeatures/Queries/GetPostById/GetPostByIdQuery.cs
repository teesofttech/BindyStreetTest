using AutoMapper;
using BindyStreet.Application.DTOs.Post.Response;
using BindyStreet.Application.Repositories;
using BindyStreet.Shared;
using MediatR;

namespace BindyStreet.Application.Features.PostFeatures.Queries.GetPostById
{
    public class GetPostByIdQuery : IRequest<Result<GetPostByIdDto>>
    {
        public int Id { get; set; }

        public GetPostByIdQuery(int id)
        {
            Id = id;
        }
    }

    internal class GetPostByIdQueryHandler : IRequestHandler<GetPostByIdQuery, Result<GetPostByIdDto>>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public GetPostByIdQueryHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<Result<GetPostByIdDto>> Handle(GetPostByIdQuery query, CancellationToken cancellationToken)
        {

            var entity = await _postRepository.GetByIdAsync(query.Id);
            var post = _mapper.Map<GetPostByIdDto>(entity);

            return await Result<GetPostByIdDto>.SuccessAsync(post);
        }

    }
}

