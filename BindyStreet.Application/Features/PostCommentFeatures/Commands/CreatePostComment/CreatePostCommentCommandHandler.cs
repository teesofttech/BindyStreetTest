using AutoMapper;
using BindyStreet.Application.DTOs.Post.Request;
using BindyStreet.Application.DTOs.PostComment.Request;
using BindyStreet.Application.Features.PostFeatures.Commands.CreatePost;
using BindyStreet.Application.Repositories;
using BindyStreet.Domain.Entities;
using BindyStreet.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindyStreet.Application.Features.PostCommentFeatures.Commands.CreatePostComment
{
    internal class CreatePostCommentCommandHandler : IRequestHandler<CreatePostCommentCommand, Result<int>>
    {
        private readonly IPostCommentRepository _postCommentRepository;
        private readonly IMapper _mapper;

        public CreatePostCommentCommandHandler(IPostCommentRepository postCommentRepository, IMapper mapper)
        {
            _postCommentRepository = postCommentRepository;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreatePostCommentCommand command, CancellationToken cancellationToken)
        {
            var postComment = _mapper.Map<CreatePostCommentRequest, Comment>(command.CreatePostCommentRequest);
            await _postCommentRepository.AddAsync(postComment);
            return await Result<int>.SuccessAsync(postComment.Id, "Post Comment Created.");
        }
    }
}
