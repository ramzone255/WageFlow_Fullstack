using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageFlow.Application.src.Entities.User.Commands.SignInUser
{
    public class SignInUserCommandValidator : AbstractValidator<SignInUserCommand>
    {
        public SignInUserCommandValidator()
        {
            RuleFor(entity => entity.user_name).MaximumLength(30).NotEmpty();
            RuleFor(entity => entity.user_password).MaximumLength(30).NotEmpty();
        }
    }
}
