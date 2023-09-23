using BindyStreet.Application.DTOs.Post.Request;
using BindyStreet.Application.DTOs.User.UserRequest;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindyStreet.Application.Validator
{
    public class CreatePostRequestValidator : AbstractValidator<CreatePostRequest>
    {
        public CreatePostRequestValidator()
        {

            RuleFor(x => x.UserId)
                .NotNull()
                .WithMessage("User Id cannot be null");

            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Title is Mandatory");

            RuleFor(x => x.Body)
                .NotEmpty()
                .WithMessage("Body is Mandatory");

        }
    }
}
