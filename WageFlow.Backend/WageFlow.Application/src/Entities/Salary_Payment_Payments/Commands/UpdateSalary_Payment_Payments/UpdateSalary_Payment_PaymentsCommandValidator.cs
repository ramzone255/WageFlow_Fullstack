using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageFlow.Application.src.Entities.Salary_Payment_Payments.Commands.UpdateSalary_Payment_Payments
{
    public class UpdateSalary_Payment_PaymentsCommandValidator
        : AbstractValidator<UpdateSalary_Payment_PaymentsCommand>
    {
        public UpdateSalary_Payment_PaymentsCommandValidator()
        {
            RuleFor(updateEntityCommand =>
            updateEntityCommand.id_salary_payment_payments).NotEmpty();
            RuleFor(updateEntityCommand =>
            updateEntityCommand.id_salary_payment).NotEmpty();
            RuleFor(updateEntityCommand =>
            updateEntityCommand.id_payments).NotEmpty();
        }
    }
}
