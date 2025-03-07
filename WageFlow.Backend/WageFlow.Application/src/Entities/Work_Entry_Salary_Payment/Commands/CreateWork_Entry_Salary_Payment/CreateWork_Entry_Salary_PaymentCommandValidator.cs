using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageFlow.Application.src.Entities.Work_Entry_Salary_Payment.Commands.CreateWork_Entry_Salary_Payment
{
    public class CreateWork_Entry_Salary_PaymentCommandValidator
        : AbstractValidator<CreateWork_Entry_Salary_PaymentCommand>
    {
        public CreateWork_Entry_Salary_PaymentCommandValidator()
        {
            RuleFor(createEntityCommand =>
            createEntityCommand.id_work_entry).NotEmpty();
            RuleFor(createEntityCommand =>
            createEntityCommand.id_salary_payment).NotEmpty();
        }
    }
}
