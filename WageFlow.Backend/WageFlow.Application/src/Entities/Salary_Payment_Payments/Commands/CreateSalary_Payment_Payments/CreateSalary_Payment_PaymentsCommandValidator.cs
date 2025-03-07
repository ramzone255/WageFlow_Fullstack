using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageFlow.Application.src.Entities.Salary_Payment_Payments.Commands.CreateSalary_Payment_Payments
{
    public class CreateSalary_Payment_PaymentsCommandValidator
        : AbstractValidator<CreateSalary_Payment_PaymentsCommand>
    {
        public CreateSalary_Payment_PaymentsCommandValidator()
        {
            RuleFor(createEntityCommand =>
            createEntityCommand.id_payments).NotEmpty();
            RuleFor(createEntityCommand =>
            createEntityCommand.id_salary_payment).NotEmpty();
        }
    }
}
