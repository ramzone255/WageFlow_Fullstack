using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageFlow.Application.src.Entities.Staff.Commands.CreateStaff
{
    public class CreateStaffCommandValidator : AbstractValidator<CreateStaffCommand>
    {
        public CreateStaffCommandValidator()
        {
            RuleFor(createEntityCommand =>
            createEntityCommand.name_staff).MaximumLength(50).NotEmpty();
            RuleFor(createEntityCommand =>
            createEntityCommand.lastname_staff).MaximumLength(50).NotEmpty();
            RuleFor(createEntityCommand =>
            createEntityCommand.patronymic_staff).MaximumLength(50).NotEmpty();
            RuleFor(createEntityCommand =>
            createEntityCommand.email_staff).MaximumLength(50).NotEmpty();
            RuleFor(createEntityCommand =>
            createEntityCommand.id_post).NotEmpty();
        }
    }
}
