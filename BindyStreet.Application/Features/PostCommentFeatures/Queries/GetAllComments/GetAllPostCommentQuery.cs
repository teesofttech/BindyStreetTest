using AutoMapper;
using BindyStreet.Application.DTOs.PostComment.Response;
using BindyStreet.Application.Repositories;
using BindyStreet.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindyStreet.Application.Features.PostCommentFeatures.Queries.GetAllComments
{
    public record class GetAllPostCommentQuery : IRequest<Result<List<GetAllPostCommentDto>>>;

    internal class GetAllPostCommentQueryHandler : IRequestHandler<GetAllPostCommentQuery, Result<List<GetAllPostCommentDto>>>
    {
        private readonly IPostCommentRepository _postCommentRepository;
        private readonly IMapper _mapper;
        public GetAllPostCommentQueryHandler(IPostCommentRepository postCommentRepository, IMapper mapper)
        {
            _postCommentRepository = postCommentRepository;
            _mapper = mapper;
        }
        public async Task<Result<List<GetAllPostCommentDto>>> Handle(GetAllPostCommentQuery request, CancellationToken cancellationToken)
        {
            var postComments = await _postCommentRepository.GetAllAsync();
            var mapped = _mapper.Map<List<GetAllPostCommentDto>>(postComments);
            return await Result<List<GetAllPostCommentDto>>.SuccessAsync(mapped);
        }
    }
}
