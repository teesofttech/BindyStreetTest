using AutoMapper;
using BindyStreet.Application.Features.PostFeatures.Commands.DeletePost;
using BindyStreet.Application.Repositories;
using BindyStreet.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindyStreet.Application.Features.PostCommentFeatures.Commands.DeletePostComment
{
    internal class DeletePostCommentHandler : IRequestHandler<DeletePostCommentCommand, Result<int>>
    {
        private readonly IPostCommentRepository _postCommentRepository;
        private readonly IMapper _mapper;

        public DeletePostCommentHandler(IPostCommentRepository postCommentRepository, IMapper mapper)
        {
            _postCommentRepository = postCommentRepository;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(DeletePostCommentCommand command, CancellationToken cancellationToken)
        {
            var post = await _postCommentRepository.GetByIdAsync(command.Id);
            if (post != null)
            {
                await _postCommentRepository.Delete(post);

                return await Result<int>.SuccessAsync(post.Id, "Post Comment Deleted");
            }
            else
            {
                return await Result<int>.FailureAsync("Post Comment Not Found.");
            }
        }
    }
}
