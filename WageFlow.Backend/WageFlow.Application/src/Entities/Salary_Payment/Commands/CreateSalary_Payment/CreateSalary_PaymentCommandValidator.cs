using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageFlow.Application.src.Entities.Salary_Payment.Commands.CreateSalary_Payment
{
    public class CreateSalary_PaymentCommandValidator
        : AbstractValidator<CreateSalary_PaymentCommand>
    {
        public CreateSalary_PaymentCommandValidator()
        {
            RuleFor(createEntityCommand =>
            createEntityCommand.end_date_salary_payment).NotEmpty();
            RuleFor(createEntityCommand =>
            createEntityCommand.start_date_salary_payment).NotEmpty();
            RuleFor(createEntityCommand =>
            createEntityCommand.id_staff).NotEmpty();
        }
    }
}
