using BindyStreet.Application.DTOs.Post.Request;
using BindyStreet.Application.DTOs.PostComment.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindyStreet.Application.Validator
{
    public class CreatePostCommentRequestValidator : AbstractValidator<CreatePostCommentRequest>
    {
        public CreatePostCommentRequestValidator()
        {

            RuleFor(x => x.Email)
                .EmailAddress()
                .NotEmpty()
                .WithMessage("Email address is Mandatory");

            RuleFor(x => x.PostId)
                .NotEmpty()
                .WithMessage("Post Id is Mandatory");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is Mandatory");

            RuleFor(x => x.Body)
                .NotEmpty()
                .WithMessage("Body is Mandatory");

        }
    }
}
