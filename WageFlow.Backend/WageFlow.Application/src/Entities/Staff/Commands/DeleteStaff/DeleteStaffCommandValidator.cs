using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageFlow.Application.src.Entities.Staff.Commands.DeleteStaff
{
    public class DeleteStaffCommandValidator
        : AbstractValidator<DeleteStaffCommand>
    {
        public DeleteStaffCommandValidator()
        {
            RuleFor(deleteEntityCommand => deleteEntityCommand.id_staff).NotEmpty();
        }
    }
}
