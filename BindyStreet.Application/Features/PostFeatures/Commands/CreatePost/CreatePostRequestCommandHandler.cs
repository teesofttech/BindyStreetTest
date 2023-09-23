using AutoMapper;
using BindyStreet.Application.DTOs.Post.Request;
using BindyStreet.Application.Repositories;
using BindyStreet.Domain.Entities;
using BindyStreet.Shared;
using MediatR;

namespace BindyStreet.Application.Features.PostFeatures.Commands.CreatePost
{
    internal class CreatePostRequestCommandHandler : IRequestHandler<CreatePostCommand, Result<int>>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public CreatePostRequestCommandHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreatePostCommand command, CancellationToken cancellationToken)
        {
            var post = _mapper.Map<CreatePostRequest, Post>(command.CreatePostRequest);
            await _postRepository.AddAsync(post);
            return await Result<int>.SuccessAsync(post.Id, "Post Created.");
        }
    }
}
