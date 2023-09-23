using BindyStreet.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindyStreet.Application.Features.PostFeatures.Commands.DeletePost
{
    public record DeletePostCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public DeletePostCommand(int id)
        {
            Id = id;
        }
    }
}
