using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageFlow.Application.src.Entities.Salary_Payment_Payments.Commands.DeleteSalary_Payment_Payments
{
    public class DeleteSalary_Payment_PaymentsCommandValidator
        : AbstractValidator<DeleteSalary_Payment_PaymentsCommand>
    {
        public DeleteSalary_Payment_PaymentsCommandValidator()
        {
            RuleFor(deleteEntityCommand => deleteEntityCommand.id_salary_payment_payments).NotEmpty();
        }
    }
}
