using BindyStreet.Application.DTOs.Post.Request;
using BindyStreet.Application.DTOs.User.Request;
using BindyStreet.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindyStreet.Application.Features.PostFeatures.Commands.UpdatePost
{
    public class UpdatePostCommand : IRequest<Result<int>>
    {
        public UpdatePostRequest UpdatePostRequest { get; set; }
    }
}
