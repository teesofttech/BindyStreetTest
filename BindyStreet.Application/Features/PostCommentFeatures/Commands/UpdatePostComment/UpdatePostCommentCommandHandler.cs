using AutoMapper;
using BindyStreet.Application.Features.PostFeatures.Commands.UpdatePost;
using BindyStreet.Application.Repositories;
using BindyStreet.Domain.Entities;
using BindyStreet.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindyStreet.Application.Features.PostCommentFeatures.Commands.UpdatePostComment
{
    internal class UpdatePostCommentCommandHandler : IRequestHandler<UpdatePostCommentCommand, Result<int>>
    {
        private readonly IPostCommentRepository _postCommentRepository;
        private readonly IMapper _mapper;

        public UpdatePostCommentCommandHandler(IPostCommentRepository postCommentRepository, IMapper mapper)
        {
            _postCommentRepository = postCommentRepository;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(UpdatePostCommentCommand command, CancellationToken cancellationToken)
        {
            var post = await _postCommentRepository.GetByIdAsync(command.UpdatePostCommentRequest.Id);
            if (post != null)
            {
                var mapped = _mapper.Map<Comment>(command.UpdatePostCommentRequest);
                await _postCommentRepository.Update(mapped);

                return await Result<int>.SuccessAsync(mapped.Id, "Post Comment Updated.");
            }
            else
            {
                return await Result<int>.FailureAsync("Post Comment Not Found.");
            }
        }
    }
}
