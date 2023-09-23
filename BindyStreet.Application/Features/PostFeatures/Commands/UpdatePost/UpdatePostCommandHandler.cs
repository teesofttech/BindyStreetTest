using AutoMapper;
using BindyStreet.Application.Features.UserFeatures.Commands.UpdateUser;
using BindyStreet.Application.Repositories;
using BindyStreet.Domain.Entities;
using BindyStreet.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindyStreet.Application.Features.PostFeatures.Commands.UpdatePost
{
    internal class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, Result<int>>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public UpdatePostCommandHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(UpdatePostCommand command, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetByIdAsync(command.UpdatePostRequest.Id);
            if (post != null)
            {
                var mapped = _mapper.Map<Post>(command.UpdatePostRequest);
                await _postRepository.Update(mapped);

                return await Result<int>.SuccessAsync(mapped.Id, "Post Updated.");
            }
            else
            {
                return await Result<int>.FailureAsync("Post Not Found.");
            }
        }
    }
}
