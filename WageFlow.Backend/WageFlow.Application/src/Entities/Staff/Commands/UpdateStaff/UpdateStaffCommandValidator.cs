using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageFlow.Application.src.Entities.Staff.Commands.UpdateStaff
{
    public class UpdateStaffCommandValidator
        : AbstractValidator<UpdateStaffCommand>
    {
        public UpdateStaffCommandValidator()
        {
            RuleFor(updateEntityCommand =>
            updateEntityCommand.id_staff).NotEmpty();
            RuleFor(updateEntityCommand =>
            updateEntityCommand.name_staff).MaximumLength(50).NotEmpty();
            RuleFor(updateEntityCommand =>
            updateEntityCommand.lastname_staff).MaximumLength(50).NotEmpty();
            RuleFor(updateEntityCommand =>
            updateEntityCommand.patronymic_staff).MaximumLength(50).NotEmpty();
            RuleFor(updateEntityCommand =>
            updateEntityCommand.email_staff).MaximumLength(50).NotEmpty();
            RuleFor(updateEntityCommand =>
            updateEntityCommand.id_post).NotEmpty();
        }
    }
}
