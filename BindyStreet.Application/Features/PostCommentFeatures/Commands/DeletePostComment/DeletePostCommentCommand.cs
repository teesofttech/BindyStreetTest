using BindyStreet.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindyStreet.Application.Features.PostCommentFeatures.Commands.DeletePostComment
{
    public record DeletePostCommentCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public DeletePostCommentCommand(int id)
        {
            Id = id;
        }
    }
}
