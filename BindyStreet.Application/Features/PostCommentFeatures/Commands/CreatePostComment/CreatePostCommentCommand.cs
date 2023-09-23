using BindyStreet.Application.DTOs.Post.Request;
using BindyStreet.Application.DTOs.PostComment.Request;
using BindyStreet.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindyStreet.Application.Features.PostCommentFeatures.Commands.CreatePostComment
{
    public record CreatePostCommentCommand : IRequest<Result<int>>
    {
        public CreatePostCommentRequest CreatePostCommentRequest { get; set; }
    }
}
