using AutoMapper;
using BindyStreet.Application.DTOs.Post.Response;
using BindyStreet.Application.DTOs.User.Response;
using BindyStreet.Application.Repositories;
using BindyStreet.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindyStreet.Application.Features.PostFeatures.Queries.GetAllPosts
{

    public record GetAllPostsQuery : IRequest<Result<List<GetAllPostDto>>>;

    internal class GetAllPostsQueryHandler : IRequestHandler<GetAllPostsQuery, Result<List<GetAllPostDto>>>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public GetAllPostsQueryHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<Result<List<GetAllPostDto>>> Handle(GetAllPostsQuery query, CancellationToken cancellationToken)
        {
            var posts = await _postRepository.GetAllAsync();
            var mapped = _mapper.Map<List<GetAllPostDto>>(posts);
            return await Result<List<GetAllPostDto>>.SuccessAsync(mapped);
        }
    }
}
