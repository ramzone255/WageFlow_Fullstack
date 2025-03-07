using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageFlow.Application.src.Entities.Salary_Payment.Commands.UpdateSalary_Payment
{
    public class UpdateSalary_PaymentCommandValidator
        : AbstractValidator<UpdateSalary_PaymentCommand>
    {
        public UpdateSalary_PaymentCommandValidator()
        {
            RuleFor(updateEntityCommand =>
            updateEntityCommand.id_salary_payment).NotEmpty();
            RuleFor(updateEntityCommand =>
            updateEntityCommand.start_date_salary_payment).NotEmpty();
            RuleFor(updateEntityCommand =>
            updateEntityCommand.end_date_salary_payment).NotEmpty();
            RuleFor(updateEntityCommand =>
            updateEntityCommand.id_staff).NotEmpty();
        }
    }
}
