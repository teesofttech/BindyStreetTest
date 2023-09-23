using AutoMapper;
using BindyStreet.Application.DTOs.PostComment.Response;
using BindyStreet.Application.Repositories;
using BindyStreet.Shared;
using MediatR;

namespace BindyStreet.Application.Features.PostCommentFeatures.Queries.GetCommentById
{
    public class GetPostCommentByIdQuery : IRequest<Result<GetPostCommentByIdDto>>
    {
        public int Id { get; set; }

        public GetPostCommentByIdQuery(int id)
        {
            Id = id;
        }
    }

    internal class GetPostCommentByIdQueryHandler : IRequestHandler<GetPostCommentByIdQuery, Result<GetPostCommentByIdDto>>
    {
        private readonly IPostCommentRepository _postCommentRepository;
        private readonly IMapper _mapper;

        public GetPostCommentByIdQueryHandler(IPostCommentRepository postCommentRepository, IMapper mapper)
        {
            _postCommentRepository = postCommentRepository;
            _mapper = mapper;
        }

        public async Task<Result<GetPostCommentByIdDto>> Handle(GetPostCommentByIdQuery query, CancellationToken cancellationToken)
        {

            var entity = await _postCommentRepository.GetByIdAsync(query.Id);
            var post = _mapper.Map<GetPostCommentByIdDto>(entity);
            return await Result<GetPostCommentByIdDto>.SuccessAsync(post);
        }

    }
}
