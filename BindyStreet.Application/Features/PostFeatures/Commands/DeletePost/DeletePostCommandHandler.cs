using AutoMapper;
using BindyStreet.Application.Repositories;
using BindyStreet.Shared;
using MediatR;

namespace BindyStreet.Application.Features.PostFeatures.Commands.DeletePost
{
    internal class DeletePostCommandHandler : IRequestHandler<DeletePostCommand, Result<int>>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public DeletePostCommandHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(DeletePostCommand command, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetByIdAsync(command.Id);
            if (post != null)
            {
                await _postRepository.Delete(post);

                return await Result<int>.SuccessAsync(post.Id, "Post Deleted");
            }
            else
            {
                return await Result<int>.FailureAsync("Post Not Found.");
            }
        }
    }
}
