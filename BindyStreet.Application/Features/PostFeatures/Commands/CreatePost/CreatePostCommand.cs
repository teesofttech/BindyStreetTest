using BindyStreet.Application.DTOs.Post.Request;
using BindyStreet.Application.DTOs.User.UserRequest;
using BindyStreet.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindyStreet.Application.Features.PostFeatures.Commands.CreatePost
{
    public record CreatePostCommand : IRequest<Result<int>>
    {
        public CreatePostRequest CreatePostRequest { get; set; }
    }
}
