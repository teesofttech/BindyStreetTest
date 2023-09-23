using AutoMapper;
using BindyStreet.Application.DTOs.Post.Response;
using BindyStreet.Application.DTOs.PostComment.Response;
using BindyStreet.Application.Repositories;
using BindyStreet.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindyStreet.Application.Features.PostCommentFeatures.Queries.GetAllCommentsByPostId
{
    public record GetAllCommentsByPostIdQuery : IRequest<Result<List<GetAllPostCommentDto>>>
    {
        public int Id { get; set; }
        public GetAllCommentsByPostIdQuery(int id)
        {
            Id = id;
        }
    }

    internal class GetAllCommentsByPostIdQueryHandler : IRequestHandler<GetAllCommentsByPostIdQuery, Result<List<GetAllPostCommentDto>>>
    {
        private readonly IPostCommentRepository _postCommentRepository;
        private readonly IMapper _mapper;
        public GetAllCommentsByPostIdQueryHandler(IPostCommentRepository postCommentRepository, IMapper mapper)
        {
            _postCommentRepository = postCommentRepository;
            _mapper = mapper;
        }
        public async Task<Result<List<GetAllPostCommentDto>>> Handle(GetAllCommentsByPostIdQuery request, CancellationToken cancellationToken)
        {
            var postComments = await _postCommentRepository.GetPostCommentsById(request.Id);
            var mapped = _mapper.Map<List<GetAllPostCommentDto>>(postComments);
            return await Result<List<GetAllPostCommentDto>>.SuccessAsync(mapped);
        }
    }

}
