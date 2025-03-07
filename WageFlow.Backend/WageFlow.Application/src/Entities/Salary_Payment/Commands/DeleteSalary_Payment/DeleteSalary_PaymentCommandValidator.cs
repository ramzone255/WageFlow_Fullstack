using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageFlow.Application.src.Entities.Salary_Payment.Commands.DeleteSalary_Payment
{
    public class DeleteSalary_PaymentCommandValidator
        : AbstractValidator<DeleteSalary_PaymentCommand>
    {
        public DeleteSalary_PaymentCommandValidator()
        {
            RuleFor(deleteEntityCommand => deleteEntityCommand.id_salary_payment).NotEmpty();
        }
    }
}
